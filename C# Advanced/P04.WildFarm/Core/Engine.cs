using System;
using System.Linq;
using System.Collections.Generic;

using P04.WildFarm.Factories;
using P04.WildFarm.Exceptions;
using P04.WildFarm.Core.Contracts;
using P04.WildFarm.Models.Animals;
using P04.WildFarm.Models.Foods.Contracts;
using P04.WildFarm.Models.Animals.Contracts;

namespace P04.WildFarm.Core
{
    public class Engine : IEngine
    {
        private ICollection<IAnimal> animals;
        private FoodFactory foodFactory;

        public Engine()
        {
            this.animals = new List<IAnimal>();
            this.foodFactory = new FoodFactory();
        }
        public void Run()
        {
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] animalArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string[] foodArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                IAnimal animal = ProduceAnimal(animalArgs);
                animals.Add(animal);

                string foodType = foodArgs[0];
                int foodQuantity = int.Parse(foodArgs[1]);
                IFood food = this.foodFactory.ProduceFood(foodType, foodQuantity);

                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Feed(food);
                }
                catch (FoodException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            foreach (IAnimal animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static IAnimal ProduceAnimal(string[] animalArgs)
        {
            IAnimal animal = null;

            string animalType = animalArgs[0];
            string animalName = animalArgs[1];
            double weight = double.Parse(animalArgs[2]);

            if (animalType == "Owl")
            {
                double wingSize = double.Parse(animalArgs[3]);

                animal = new Owl(animalName, weight, wingSize);
            }
            else if (animalType == "Hen")
            {
                double wingSize = double.Parse(animalArgs[3]);

                animal = new Hen(animalName, weight, wingSize);
            }
            else if (animalType == "Mouse")
            {
                string livingRegion = animalArgs[3];

                animal = new Mouse(animalName, weight, livingRegion);
            }
            else if (animalType == "Dog")
            {
                string livingRegion = animalArgs[3];

                animal = new Dog(animalName, weight, livingRegion);
            }
            else if (animalType == "Cat")
            {
                string livingRegion = animalArgs[3];
                string breed = animalArgs[4];

                animal = new Cat(animalName, weight, livingRegion, breed);
            }
            else if (animalType == "Tiger")
            {
                string livingRegion = animalArgs[3];
                string breed = animalArgs[4];

                animal = new Tiger(animalName, weight, livingRegion, breed);
            }

            return animal;
        }
    }
}
