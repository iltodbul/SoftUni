using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Weaponsmith
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> weaponName = Console.ReadLine().Split("|").ToList();
            var commands = Console.ReadLine().Split().ToList();

            while (commands[0] != "Done")
            {
                if (commands[1] == "Left")
                {
                    int index = int.Parse(commands[2]);
                    int leftIndex = index - 1;
                    if (index >= 0 && index < weaponName.Count && leftIndex >= 0 && leftIndex < weaponName.Count)
                    {
                        string value = weaponName[index];
                        weaponName.RemoveAt(index);
                        weaponName.Insert(leftIndex, value);

                    }
                }
                else if (commands[1] == "Right")
                {
                    int index = int.Parse(commands[2]);
                    int rightIndex = index + 1;
                    if (index >= 0 && index < weaponName.Count && rightIndex >= 0 && rightIndex < weaponName.Count)
                    {
                        string value = weaponName[index];
                        weaponName.RemoveAt(index);
                        weaponName.Insert(rightIndex, value);

                    }
                }
                else if (commands[1] == "Even")
                {
                    var filtredList = new List<string>();
                    for (int i = 0; i < weaponName.Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            string toAdd = weaponName[i];
                            filtredList.Add(toAdd);
                        }
                        
                    }
                    Console.WriteLine(string.Join(" ", filtredList));
                }
                else if (commands[1] == "Odd")
                {
                    var filtredList = new List<string>();
                    for (int i = 0; i < weaponName.Count; i++)
                    {
                        if (i % 2 != 0)
                        {
                            string toAdd = weaponName[i];
                            filtredList.Add(toAdd);
                        }

                    }
                    Console.WriteLine(string.Join(" ", filtredList));
                }

                commands = Console.ReadLine().Split().ToList();
            }
            Console.WriteLine($"You crafted {string.Join("",weaponName)}!");
        }
    }
}
