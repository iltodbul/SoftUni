using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._On_the_Way_to_Annapurna
{
    class Program
    {
        static void Main(string[] args)
        {
            var storesList = new Dictionary<string, List<string>>();

            string line = Console.ReadLine();
            while (line != "END")
            {
                string[] commands = line.Split("->");
                string token = commands[0];
                string store = commands[1];
                if (token == "Add")
                {
                    string[] items = commands[2].Split(',');

                    if (!storesList.ContainsKey(store))
                    {
                        storesList.Add(store, new List<string>());
                    }
                    for (int i = 0; i < items.Length; i++)
                    {
                        storesList[store].Add(items[i]);
                    }

                }
                else if (token == "Remove")
                {
                    if (storesList.ContainsKey(store))
                    {
                        storesList.Remove(store);
                    }
                }

                line = Console.ReadLine();
            }
            Console.WriteLine("Stores list:");
            
            foreach (var store in storesList
                .OrderByDescending(x=>x.Value.Count)
                .ThenByDescending(x=>x.Key))
            {
                Console.WriteLine(store.Key);
                
                foreach (var item in store.Value)
                {
                    Console.WriteLine($"<<{item}>>");

                }
            }
                
        }
    }
}
