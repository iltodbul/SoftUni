using System;
using System.Collections.Generic;
using System.Linq;

namespace P03._Inbox_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = new Dictionary<string, List<string>>();

            string line = Console.ReadLine();
            while (line != "Statistics")
            {
                string[] commands = line.Split("->");

                if (commands[0] == "Add")
                {
                    string username = commands[1];
                    if (!database.ContainsKey(username))
                    {
                        database.Add(username, new List<string>());

                    }
                    else
                    {
                        Console.WriteLine($"{username} is already registered");
                    }
                }
                else if (commands[0] == "Send")
                {
                    string username = commands[1];
                    string email = commands[2];
                    database[username].Add(email);
                }
                else if (commands[0] == "Delete")
                {
                    string username = commands[1];
                    if (database.ContainsKey(username))
                    {
                        database.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} not found!");
                    }
                }

                line = Console.ReadLine();
            }

            database = database.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"Users count: {database.Keys.Count}");
            foreach (var user in database)
            {
                Console.WriteLine(user.Key);
                foreach (var emails in user.Value)
                {
                    Console.WriteLine($"- {emails}");
                }
            }
        }
    }
}
