using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

namespace StringManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] comands = Console.ReadLine().Split().ToArray();

            while (comands[0] != "Done")
            {
                string token = comands[0];
                switch (token)
                {
                    case "Change":
                        char oldChar = comands[1][0];
                        string newChar = comands[2][0].ToString().ToLower();//change upper or lower case?
                        text = text.Replace(oldChar, char.Parse(newChar));
                        Console.WriteLine(text);
                        break;
                    case "Includes":
                        string toCheck = comands[1];
                        Console.WriteLine(text.Contains(toCheck));
                        break;
                    case "End":
                        toCheck = comands[1];
                        Console.WriteLine(text.EndsWith(toCheck));
                        break;
                    case "Uppercase":
                        text = text.ToUpper();
                        Console.WriteLine(text);
                        break;
                    case "FindIndex":
                        char find = comands[1][0];
                        int index = text.IndexOf(find);
                        Console.WriteLine(index);
                        break;
                    case "Cut":
                        int startIndex = int.Parse(comands[1]);
                        int lenght = int.Parse(comands[2]);
                        string cuted = text.Substring(startIndex,lenght);
                        Console.WriteLine(cuted);
                            break;

                }

                comands = Console.ReadLine().Split().ToArray();
            }
        }
    }
}
