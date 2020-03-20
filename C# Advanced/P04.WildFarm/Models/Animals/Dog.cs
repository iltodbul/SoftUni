﻿using System;
using System.Collections.Generic;

using P04.WildFarm.Models.Foods;

namespace P04.WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const double DogWeightMultiplier = 0.40;

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {

        }

        public override double WeightMultiplier => DogWeightMultiplier;

        public override ICollection<Type> PrefferedFoods => new List<Type>() { typeof(Meat)};

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return base.ToString() + $" {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
