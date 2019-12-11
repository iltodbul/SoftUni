using System;
using System.Collections.Generic;
using System.Linq;

namespace Man_O_War
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> statusPrateShip = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            List<int> statusWarship = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            int maximumHealth = int.Parse(Console.ReadLine());
            double minimumHealth = maximumHealth * 0.2;

            List<string> command = Console.ReadLine().Split().ToList();

            while (command[0] != "Retire")
            {
                if (command[0] == "Fire")//Pirate attack. Manipulait Warship
                {
                    int indexSection = int.Parse(command[1]);
                    int damage = int.Parse(command[2]);

                    if (CheckIndex(statusWarship, indexSection))
                    {
                        statusWarship[indexSection] -= damage;
                        if (statusWarship[indexSection] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }
                    }
                   

                }
                else if (command[0] == "Defend")//Warship attack. Manipulait Pirate
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);
                    int damage = int.Parse(command[3]);
                    if (ChekRange(statusPrateShip, startIndex, endIndex))
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            statusPrateShip[i] -= damage;
                            if (statusPrateShip[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                return;
                            }
                        }
                        
                    }

                }
                else if (command[0] == "Repair")//Repair Pirate
                {
                    int indexSection = int.Parse(command[1]);
                    int health = int.Parse(command[2]);
                    if (CheckIndex(statusPrateShip,indexSection))
                    {
                        if (statusPrateShip[indexSection]+health>maximumHealth)
                        {
                            statusPrateShip[indexSection] = maximumHealth;
                        }
                        else
                        {
                            statusPrateShip[indexSection] += health;
                        }
                    }
                }
                else if (command[0] == "Status")//Status Pirate
                {
                    int count = 0;
                    for (int i = 0; i < statusPrateShip.Count; i++)
                    {
                        int currentStatus = statusPrateShip[i];
                        if (currentStatus< minimumHealth)
                        {
                            count++;
                        }
                    }
                    if (count>0)
                    {
                        Console.WriteLine($"{count} sections need repair.");
                    }
                }

                command = Console.ReadLine().Split().ToList();
            }
            Console.WriteLine($"Pirate ship status: {statusPrateShip.Sum()}");
            Console.WriteLine($"Warship status: {statusWarship.Sum()}");
        }

        static bool CheckIndex(List<int> statusWareship, int index)
        {
            bool indexIsValid = false;
            if (index >= 0 && index <= statusWareship.Count - 1)
            {
                indexIsValid = true;
            }
            return indexIsValid;
        }

        static bool ChekRange(List<int> list, int startIndex, int endIndex)
        {
            bool rangeIsValid = false;
            if (startIndex >= 0 && startIndex < endIndex && endIndex <= list.Count - 1 && endIndex > startIndex)
            {
                rangeIsValid = true;
            }
            return rangeIsValid;
        }
    }
}
