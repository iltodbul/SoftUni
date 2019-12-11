using System;
using System.Collections.Generic;
using System.Linq;

namespace Treasure_Hunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> treasure = Console.ReadLine().Split('|').ToList();

            List<string> commands = Console.ReadLine().Split().ToList();
            string token = commands[0];

            while (commands[0] != "Yohoho!")
            {
                if (commands[0] == "Loot")
                {
                    for (int i = 1; i < commands.Count; i++)
                    {
                        string item = commands[i];
                        if (!treasure.Contains(item))
                        {
                            treasure.Insert(0, item);
                        }
                    }

                }
                else if (commands[0] == "Drop")
                {
                    int index = int.Parse(commands[1]);
                    if (index >= 0 && index < treasure.Count - 1)
                    {
                        string theItem = treasure[index];
                        treasure.RemoveAt(index);
                        treasure.Add(theItem);
                    }
                }
                else if (commands[0] == "Steal")
                {
                    int count = int.Parse(commands[1]);
                    List<string> stealsItem = new List<string>();
                    if (count > treasure.Count - 1)
                    {
                        count = treasure.Count;
                    }
                    if (count >= 0 && count <= treasure.Count)
                    {

                        for (int i = 0; i < count; i++)
                        {
                            string item = treasure[treasure.Count - 1];
                            treasure.RemoveAt(treasure.Count - 1);
                            stealsItem.Insert(0, item);
                        }
                        Console.WriteLine(string.Join(", ", stealsItem));
                    }


                }
                commands = Console.ReadLine().Split().ToList();
            }
            int sum = 0;
            for (int i = 0; i < treasure.Count; i++)
            {
                string currentWord = treasure[i];
                int length = currentWord.Length;
                sum += length;
            }
            if (treasure.Count > 0)
            {
                double averageGain = sum * 1.0 / treasure.Count;
                Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }


        }
    }
}
