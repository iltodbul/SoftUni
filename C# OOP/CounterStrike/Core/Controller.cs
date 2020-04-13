using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using CounterStrike.Models.Guns;
using CounterStrike.Models.Maps;
using CounterStrike.Repositories;
using CounterStrike.Models.Players;
using CounterStrike.Core.Contracts;
using CounterStrike.Utilities.Messages;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private GunRepository guns;
        private PlayerRepository players;
        private Map map;
        private List<IPlayer> livePlayers;

        public Controller()
        {
            this.livePlayers = new List<IPlayer>();

            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = null;

            if (type == nameof(Pistol))
            {
                gun = new Pistol(name, bulletsCount);
            }
            else if (type == nameof(Rifle))
            {
                gun = new Rifle(name, bulletsCount);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            this.guns.Add(gun);

            string message = string.Format(OutputMessages.SuccessfullyAddedGun, gun.Name);

            return message;
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IGun gun = guns.FindByName(gunName);

            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            IPlayer player = null;

            if (type == nameof(Terrorist))
            {
                player = new Terrorist(username, health, armor, gun);
            }
            else if (type == nameof(CounterTerrorist))
            {
                player = new CounterTerrorist(username, health, armor, gun);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            this.players.Add(player);

            string message = string.Format(OutputMessages.SuccessfullyAddedPlayer, player.Username);

            return message;
        }

        public string StartGame()
        {
            livePlayers = players
                .Models.Where(p => p.IsAlive)
                .ToList();

            return this.map.Start(this.livePlayers);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            var toPrint = players.Models
                .OrderBy(p => p.GetType().Name)
                .ThenByDescending(p => p.Health)
                .ThenBy(p => p.Username)
                .ToList();

            foreach (var player in toPrint)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
