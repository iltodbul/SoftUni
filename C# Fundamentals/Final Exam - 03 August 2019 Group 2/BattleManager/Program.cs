using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

namespace BattleManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var peoples = new Dictionary<string, List<int>>(); //index 0-> health; index 1-> energy 

            string line = Console.ReadLine();
            while (line != "Results")
            {
                string[] token = line.Split(":").ToArray();
                string command = token[0];
                switch (command)
                {
                    case "Add":
                        string name = token[1];
                        int health = int.Parse(token[2]);
                        int energy = int.Parse(token[3]);
                        if (!peoples.ContainsKey(name))
                        {
                            peoples.Add(name, new List<int>());
                            peoples[name].Add(0);
                            peoples[name].Add(0);
                        }
                        peoples[name][0] += health;
                        peoples[name][1] += energy;
                        break;

                    case "Attack":
                        string attackerName = token[1];
                        string defenderName = token[2];
                        int damage = int.Parse(token[3]);
                        if (peoples.ContainsKey(attackerName) && peoples.ContainsKey(defenderName))
                        {
                            peoples[defenderName][0] -= damage;
                            peoples[attackerName][1] -= 1;
                            if (peoples[defenderName][0] <= 0)
                            {
                                peoples.Remove(defenderName);
                                Console.WriteLine($"{defenderName} was disqualified!");
                            }
                            if (peoples[attackerName][1] <= 0)
                            {
                                peoples.Remove(attackerName);
                                Console.WriteLine($"{attackerName} was disqualified!");
                            }
                        }
                        break;

                    case "Delete":
                        string username = token[1];
                        if (username == "All")
                        {
                            peoples.Clear();
                        }
                        if (peoples.ContainsKey(username))
                        {
                            peoples.Remove(username);
                        }
                        
                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine($"People count: {peoples.Keys.Count()}");

            peoples = peoples.OrderByDescending(x => x.Value[0])
                .ThenBy(x => x.Key)
                .ToDictionary(a=>a.Key,b=>b.Value);
            foreach (var item in peoples)
            {
                Console.WriteLine($"{item.Key} - {item.Value[0]} - {item.Value[1]}");
            }
        }
    }
}
