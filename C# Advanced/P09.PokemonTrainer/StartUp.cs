using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            while (command!= "Tournament")
            {
                var toknes = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string trainerName = toknes[0];
                string pokemonName = toknes[1];
                string pokemonElement = toknes[2];
                int pokemonHealth = int.Parse(toknes[3]);

                Pokemon pokemon = new Pokemon(pokemonName,pokemonElement,pokemonHealth);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers[trainerName] = new Trainer(trainerName);
                }
                trainers[trainerName].Pokemons.Add(pokemon);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command!="End")
            {
                if (command=="Fire")
                {
                    CheckTrainer(trainers, command);
                }
                else if (command=="Water")
                {
                    CheckTrainer(trainers, command);
                }
                else if (command== "Electricity")
                {
                    CheckTrainer(trainers, command);
                }

                command = Console.ReadLine();
            }

            foreach (Trainer trainer in trainers.Values.OrderByDescending(t=>t.Badges))
            {
                Console.WriteLine(trainer);
            }
        }

        public static void CheckTrainer (Dictionary<string,Trainer> trainers, string command)
        {
            foreach (Trainer trainer in trainers.Values)
            {
                if (trainer.Pokemons.Any(p=>p.Element==command))
                {
                    trainer.Badges++;
                }
                else
                {
                    foreach (Pokemon pokemon in trainer.Pokemons)
                    {
                        pokemon.Health -= 10;
                    }
                }

            }

            foreach (Trainer trainer in trainers.Values)
            {
                for (int i = 0; i < trainer.Pokemons.Count; i++)
                {
                    if (trainer.Pokemons[i].Health<=0)
                    {
                        trainer.Pokemons.RemoveAt(i);
                        i--;
                    }
                }
            }
        }
    }
}
