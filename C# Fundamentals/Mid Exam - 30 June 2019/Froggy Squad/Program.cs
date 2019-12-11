using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy_Squad
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> frogList = Console.ReadLine().Split(" ").ToList();
            List<string> command = Console.ReadLine().Split().ToList();

            while (command[0] != "Print")
            {
                if (command[0] == "Join")
                {
                    for (int i = 1; i < command.Count; i++)
                    {
                        string nameCurrentFrog = command[i];
                        frogList.Add(nameCurrentFrog);
                    }

                }
                else if (command[0] == "Jump")
                {
                    string name = command[1];
                    int index = int.Parse(command[2]);
                    if (ChekIndex(frogList, index))
                    {
                        frogList.Insert(index, name);
                    }

                }
                else if (command[0] == "Dive")
                {
                    int indexDive = int.Parse(command[1]);
                    if (ChekIndex(frogList, indexDive))
                    {
                        frogList.RemoveAt(indexDive);
                    }
                }
                else if (command[0] == "First")
                {
                    List<string> listFurst = new List<string>();
                    int countFirst = int.Parse(command[1]);
                    int startIndex = 0;
                    if (countFirst > frogList.Count)
                    {
                        countFirst = frogList.Count - 1;
                    }
                    if (countFirst>0)
                    {
                        for (int i = startIndex; i <= countFirst; i++)
                        {
                            string frogToAdd = frogList[i];
                            listFurst.Add(frogToAdd);
                        }
                    }
                    
                    if (listFurst.Count>0)
                    {
                        Console.WriteLine(string.Join(" ", listFurst));
                    }
                    
                }
                else if (command[0] == "Last")
                {
                    List<string> listLast = new List<string>();
                    int countLast = int.Parse(command[1]);
                    int startIndex = frogList.Count - countLast;
                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    int endIndex = frogList.Count - 1;

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        string frogToAdd = frogList[i];
                        listLast.Add(frogToAdd);
                    }
                    if (listLast.Count>0)
                    {
                        Console.WriteLine(string.Join(" ", listLast));
                    }
                }
                command = Console.ReadLine().Split().ToList();
            }
            if (command[1] == "Normal" && frogList.Count>0)
            {
                Console.WriteLine($"Frogs: {string.Join(" ", frogList)}");
            }
            if (command[1] == "Reversed" && frogList.Count>0)
            {
                frogList.Reverse();
                Console.WriteLine($"Frogs: {string.Join(" ", frogList)}");
            }
        }

        static bool ChekIndex(List<string> frogList, int index)
        {
            return index >= 0 && index < frogList.Count;
        }
    }
}
