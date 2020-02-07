using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Pokemon
    {
        private string pokemonName;
        private string element;
        private int health;

        public Pokemon(string pokemonName, string element, int health)
        {
            this.PkokemonName = pokemonName;
            this.Element = element;
            this.Health = health;
        }

        public string PkokemonName { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
    }
}
