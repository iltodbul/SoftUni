using System;
using System.Collections.Generic;
using System.Linq;

namespace P01._Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> members = new Dictionary<string, List<string>>();
            var times = new Dictionary<string, uint>();

            string line = Console.ReadLine();
            while (line != "start of concert")
            {
                string[] commands = line.Split("; ");
                string acction = commands[0];
                string bandName = commands[1];

                if (acction == "Add")
                {
                    List<string> membersName = commands[2].Split(", ").ToList();
                    if (!members.ContainsKey(bandName))
                    {
                        members.Add(bandName, new List<string>());
                    }
                    for (int i = 0; i < membersName.Count; i++)
                    {
                        string member = membersName[i];
                        if (!members[bandName].Contains(member))
                        {
                            members[bandName].Add(member);
                        }
                    }
                }
                else if (acction == "Play")
                {
                    uint time = uint.Parse(commands[2]);
                    if (!times.ContainsKey(bandName))
                    {
                        times.Add(bandName, 0);
                    }
                    times[bandName] += time;
                }
                line = Console.ReadLine();
            }
            string bandToPrint= Console.ReadLine();

            uint totalTime = 0;
            foreach (var item in times)
            {
                totalTime += item.Value;
            }
            Console.WriteLine($"Total time: {totalTime}");

            foreach (var time in times.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{time.Key} -> {time.Value}");
            }

            Console.WriteLine(bandToPrint);

            foreach (var item in members)
            {
                if (item.Key == bandToPrint)
                {
                    for (int i = 0; i < item.Value.Count; i++)
                    {
                        Console.WriteLine($"=> {item.Value[i]}");
                    }
                    
                }

            }
        }
    }
}
