using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P02.FeedTheAnimals
{
    class Program
    {
        static void Main(string[] args)
        {
            var animal = new Dictionary<string, int>();
            var areas = new Dictionary<string, int>();

            string line = Console.ReadLine();

            while (line != "Last Info")
            {
                string[] commands = line.Split(':');

                if (commands[0] == "Add")
                {
                    string animalName = commands[1];
                    int foodLimit = int.Parse(commands[2]);
                    string area = commands[3];

                    if (!animal.ContainsKey(animalName))
                    {
                        animal.Add(animalName, 0);
                        if (!areas.ContainsKey(area))
                        {
                            areas.Add(area, 0);
                        }
                        areas[area]++;

                    }
                    animal[animalName] += foodLimit;   
                }
                else
                {
                    string animalName = commands[1];
                    int food = int.Parse(commands[2]);
                    string area = commands[3];

                    if (animal.ContainsKey(animalName))
                    {
                        animal[animalName] -= food;

                        if (animal[animalName] <= 0)
                        {
                            animal.Remove(animalName);
                            areas[area]--;//need to check area?
                            Console.WriteLine($"{animalName} was successfully fed");
                        }
                    }
                }
                line = Console.ReadLine();
            }

            animal = animal.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(a=>a.Key,b=>b.Value);
            areas = areas.OrderByDescending(x => x.Value)
                .ToDictionary(a => a.Key, b => b.Value);

            Console.WriteLine("Animals:");
            foreach (var item in animal)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}g");
            }
            Console.WriteLine("Areas with hungry animals:");
            foreach (var item in areas)
            {
                if (item.Value!=0)
                {
                    Console.WriteLine($"{item.Key} : {item.Value}");
                }
            }
        }
    }
}
