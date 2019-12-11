using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Followers
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            var datebase = new Dictionary<string, List<int>>();

            while (line != "Log out")
            {
                string[] command = line.Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (command[0] == "New follower")
                {
                    string username = command[1];
                    if (!datebase.ContainsKey(username))
                    {
                        datebase.Add(username, new List<int>());
                        datebase[username].Add(0);
                        datebase[username].Add(0);
                    }

                }
                else if (command[0] == "Like")
                {
                    string username = command[1];
                    int count = int.Parse(command[2]);

                    if (!datebase.ContainsKey(username))
                    {
                        datebase.Add(username, new List<int>());
                        datebase[username].Add(0);
                        datebase[username].Add(0);
                    }
                    datebase[username][0] += count;
                }
                else if (command[0] == "Comment")
                {
                    string username = command[1];

                    if (!datebase.ContainsKey(username))
                    {
                        datebase.Add(username, new List<int>());
                        datebase[username].Add(0);
                        datebase[username].Add(0);
                    }
                    datebase[username][1] += 1;
                }
                else if (command[0] == "Blocked")
                {
                    string username = command[1];

                    if (!datebase.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                    else
                    {
                        datebase.Remove(username);
                    }
                }
                line = Console.ReadLine();
            }
            Console.WriteLine($"{datebase.Count} followers");
            foreach (var item in datebase
                .OrderByDescending(x => x.Value[0])
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value[0] + item.Value[1]}");
            }
        }
    }
}
