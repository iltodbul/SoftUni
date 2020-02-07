using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        private string trainerName;
        private int badges = 0;
        private List<Pokemon> pokemons;

        public Trainer(string trainerName)
        {
            this.TrainerName = trainerName;
            this.Badges = badges;
            this.Pokemons = new List<Pokemon>();
        }

        public string TrainerName { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public override string ToString()
        {
            return $"{this.TrainerName} {this.Badges} {this.Pokemons.Count}";
        }
    }
}
