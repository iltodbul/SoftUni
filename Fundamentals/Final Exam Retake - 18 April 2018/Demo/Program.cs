using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var animal = new Dictionary<string, int>();
            var areas = new Dictionary<string, int>();
            string[] input = Console.ReadLine().Split(":");

            while (input[0] != "Last Info")
            {
                string command = input[0];
                string animalName = input[1];
                string area = input[3];

                if (command == "Add")
                {
                    int dailyFoodLimit = int.Parse(input[2]);
                    if (!animal.ContainsKey(animalName))
                    {
                        animal.Add(animalName, 0);
                        if (!areas.ContainsKey(area))
                        {
                            areas.Add(area, 0);
                        }
                        areas[area]++;
                    }
                    animal[animalName] += dailyFoodLimit;
                    
                }
                else
                {
                    int food = int.Parse(input[2]);
                    if (animal.ContainsKey(animalName))
                    {
                        animal[animalName] -= food;
                        if (animal[animalName] <= 0)
                        {
                            Console.WriteLine($"{animalName} was successfully fed");
                            animal.Remove(animalName);
                            areas[area]--;
                        }
                    }
                }
                input = Console.ReadLine().Split(":");
            }

            animal = animal.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            areas = areas.OrderByDescending(x => x.Value).ToDictionary(x=>x.Key,x=>x.Value);

            Console.WriteLine("Animals:");

            foreach (var k in animal)
            {
                Console.WriteLine($"{k.Key} -> {k.Value}g");
            }

            Console.WriteLine("Areas with hungry animals:");

            foreach (var k in areas)
            {
                if (k.Value>0)
                {
                    Console.WriteLine($"{k.Key} : {k.Value}");
                }
                
            }
        }
    }
}
