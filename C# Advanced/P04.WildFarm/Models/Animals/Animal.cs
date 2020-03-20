using System;
using System.Collections.Generic;

using P04.WildFarm.Exceptions;
using P04.WildFarm.Models.Foods.Contracts;
using P04.WildFarm.Models.Animals.Contracts;

namespace P04.WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private const string DefoultExceptionMessage = "{0} does not eat {1}!";

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract double WeightMultiplier { get; }

        public abstract string ProduceSound();

        public abstract ICollection<Type> PrefferedFoods { get; }

        public void Feed(IFood food)
        {
            if (!this.PrefferedFoods.Contains(food.GetType()))
            {
                throw new FoodException(string.Format(DefoultExceptionMessage, this.GetType().Name, food.GetType().Name));
            }

            this.Weight += this.WeightMultiplier * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name},";
        }
    }
}
