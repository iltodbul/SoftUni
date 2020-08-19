namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;
    using VaporStore.Helper;

    public static class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        private const string SuccessfullyImportedGame
            = "Added {0} ({1}) with {2} tags";
        //Added {gameName} ({gameGenre}) with {tagsCount} tags

        private const string SuccessfullyImportedUser
            = "Imported {0} with {1} cards";
        //Imported {username} with {cardsCount} cards

        private const string SuccessfullyImportedPurchase
            = "Imported {0} for {1}";
        //Imported {gameName} for {username}

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var gamesDtos = JsonConvert.DeserializeObject<ImportGamesDTO[]>(jsonString);

            var games = new List<Game>();
            var tags = new List<Tag>();
            var genres = new List<Genre>();
            var developers = new List<Developer>();

            foreach (var gameDto in gamesDtos)
            {
                if (!IsValid(gameDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime validReliseDate;
                bool isValidReliseDate = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out validReliseDate);

                if (!isValidReliseDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (gameDto.Tags.Length == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var game = new Game()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = validReliseDate
                };

                var dev = developers
                    .FirstOrDefault(d => d.Name == gameDto.DeveloperName);

                if (dev == null)
                {
                    var newDev = new Developer() { Name = gameDto.DeveloperName };
                    developers.Add(newDev);
                    game.Developer = newDev;
                }
                else
                {
                    game.Developer = dev;
                }

                var genre = genres
                    .FirstOrDefault(g => g.Name == gameDto.GenreName);

                if (genre == null)
                {
                    var newGenre = new Genre() { Name = gameDto.GenreName };
                    genres.Add(newGenre);
                    game.Genre = newGenre;
                }
                else
                {
                    game.Genre = genre;
                }

                foreach (var tagName in gameDto.Tags)
                {
                    if (String.IsNullOrEmpty(tagName))
                    {
                        continue;
                    }

                    var tag = tags
                        .FirstOrDefault(t => t.Name == tagName);

                    if (tag == null)
                    {
                        var newTag = new Tag() { Name = tagName };
                        tags.Add(newTag);
                        game.GameTags.Add(new GameTag()
                        {
                            Game = game,
                            Tag = newTag
                        });
                    }
                    else
                    {
                        game.GameTags.Add(new GameTag()
                        {
                            Game = game,
                            Tag = tag
                        });
                    }
                }

                if (game.GameTags.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                games.Add(game);
                var gameName = game.Name;
                var gameGenre = game.Genre.Name;
                var tagsCount = game.GameTags.Count;
                sb.AppendLine(String.Format(SuccessfullyImportedGame, gameName, gameGenre, tagsCount));
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var userDtos = JsonConvert.DeserializeObject<ImportUserDTO[]>(jsonString);

            var users = new List<User>();

            foreach (var userDto in userDtos)
            {
                if (!IsValid(userDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var userCards = new List<Card>();
                bool areAllCardsValid = true;

                foreach (var cardDto in userDto.Cards)
                {

                    if (!IsValid(cardDto))
                    {
                        areAllCardsValid = false;
                        break;
                    }

                    object validCardType;
                    bool isValidCardType = Enum.TryParse(typeof(CardType), cardDto.Type, out validCardType);

                    if (!isValidCardType)
                    {
                        areAllCardsValid = false;
                        break;
                    }

                    userCards.Add(new Card()
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.Cvc,
                        Type = (CardType)validCardType
                    });

                }

                if (!areAllCardsValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (userCards.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var user = new User()
                {
                    Age = userDto.Age,
                    Username = userDto.Username,
                    FullName = userDto.FullName,
                    Email = userDto.Email,
                    Cards = userCards
                };

                users.Add(user);
                sb.AppendLine(String.Format(SuccessfullyImportedUser, user.Username, user.Cards.Count));
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var purchasesDtos = XMLConverter.Deserializer<ImportPurchaseDTO>(xmlString, "Purchases");

            var purchases = new List<Purchase>();

            foreach (var purchaseDto in purchasesDtos)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                object validPurchaseType;
                bool isValidPurchaseType = Enum.TryParse(typeof(PurchaseType), purchaseDto.Type, out validPurchaseType);

                if (!isValidPurchaseType)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime validDate;
                bool isDateValid = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out validDate);

                if (!isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var card = context
                    .Cards
                    .FirstOrDefault(c => c.Number == purchaseDto.CardNumber);

                if (card == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var game = context
                    .Games
                    .FirstOrDefault(g=>g.Name == purchaseDto.GameTitle);

                if (game == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var purchase = new Purchase()
                {
                    Game = game,
                    Card = card,
                    Date = validDate,
                    ProductKey = purchaseDto.ProductKey,
                    Type = (PurchaseType)validPurchaseType
                };

                purchases.Add(purchase);
                var gameName = purchase.Game.Name;
                var userName = purchase.Card.User.Username;
                sb.AppendLine(String.Format(SuccessfullyImportedPurchase, gameName, userName));
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}