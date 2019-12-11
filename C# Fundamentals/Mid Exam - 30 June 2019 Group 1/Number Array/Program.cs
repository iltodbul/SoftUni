using System;
using System.Collections.Generic;
using System.Linq;

namespace Number_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0] != "End")
            {
                if (command[0] == "Switch")
                {
                    int index = int.Parse(command[1]);
                    if (index >= 0 && index < array.Length)
                    {
                        int newNumber = array[index] * -1;
                        array[index] = newNumber;
                    }
                }
                else if (command[0] == "Change")
                {
                    int index = int.Parse(command[1]);
                    int value = int.Parse(command[2]);
                    if (index >= 0 && index < array.Length)
                    {
                        array[index] = value;
                    }

                }
                else if (command[1] == "Negative")
                {
                    int print = (from x in array where x < 0 select x).Sum();
                    Console.WriteLine(print);
                }
                else if (command[1] == "Positive")
                {
                    int sum = 0;
                    foreach (var item in array)
                    {
                        if (item > 0)
                        {
                            sum += item;
                        }
                    }
                    Console.WriteLine(sum);
                }
                else if (command[1] == "All")
                {
                    int sum = array.Sum();
                    Console.WriteLine(sum);
                }

                command = Console.ReadLine().Split().ToArray();
            }
            var positivNumber = new List<int>();
            foreach (var item in array)
            {
                if (item>=0)
                {
                    positivNumber.Add(item);
                }
            }
            Console.WriteLine(string.Join(" ",positivNumber));
        }
    }
}
