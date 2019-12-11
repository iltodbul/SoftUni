using System;
using System.Collections.Generic;
using System.Linq;

namespace P03._Messages_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = new Dictionary<string, List<int>>(); //index 0-> sent; index 1-> received;

            int capacity = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            while (line != "Statistics")
            {
                string[] commands = line.Split('=');
                string token = commands[0];
                if (token == "Add")
                {
                    string username = commands[1];
                    int sent = int.Parse(commands[2]);
                    int received = int.Parse(commands[3]);
                    if (!database.ContainsKey(username))
                    {
                        database.Add(username, new List<int>());
                        database[username].Add(0);
                        database[username].Add(0);
                        database[username][0] += sent;
                        database[username][1] += received;
                    }
                }
                else if (token == "Message")
                {
                    string sender = commands[1];
                    string receiver = commands[2];
                    if (database.ContainsKey(sender) && database.ContainsKey(receiver))
                    {
                        database[sender][0]++;
                        database[receiver][1]++;
                        int capacitySender = database[sender][0] + database[sender][1];
                        int capacityReceiver = database[receiver][0] + database[receiver][1];
                        
                        if (capacitySender>=capacity)
                        {
                            database.Remove(sender);
                            Console.WriteLine($"{sender} reached the capacity!");
                        }
                        if (capacityReceiver>=capacity)
                        {
                            database.Remove(receiver);
                            Console.WriteLine($"{receiver} reached the capacity!");
                        }
                    }                    
                }
                else if (token == "Empty")
                {
                    string username = commands[1];
                    if (username=="All")
                    {
                        database.Clear();
                    }
                    else
                    {
                        if (database.ContainsKey(username))
                        {
                            database.Remove(username);
                        }
                    }
                }

                line = Console.ReadLine();
            }

            database = database.OrderByDescending(x => x.Value[1])
                .ThenBy(x => x.Key)
                .ToDictionary(x=>x.Key,x=>x.Value);

            Console.WriteLine($"Users count: {database.Count}");

            foreach (var item in database)
            {
                Console.WriteLine($"{item.Key} - {item.Value.Sum()}");
            }
        }
    }
}
