using System;

namespace P01._String_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string line = Console.ReadLine();

            bool isLowercase = false;

            while (line != "End")
            {
                string[] command = line.Split(' ');
                string token = command[0];

                if (token == "Translate")
                {
                    char ch = char.Parse(command[1]);
                    char newChar = char.Parse(command[2]);
                    text = text.Replace(ch, newChar);
                    Console.WriteLine(text);
                }
                else if (token == "Includes")
                {
                    string str = command[1];
                    Console.WriteLine(text.Contains(str));
                }
                else if (token == "Start")
                {
                    string str = command[1];
                    Console.WriteLine(text.StartsWith(str));
                }
                else if (token == "Lowercase")
                {
                    text = text.ToLower();
                    Console.WriteLine(text);
                    isLowercase = true;
                }
                else if (token == "FindIndex")
                {
                    string ch = command[1];
                    if (isLowercase)
                    {
                        ch = ch.ToLower();
                    }
                    char newCh = char.Parse(ch);
                    int index = text.LastIndexOf(newCh);
                    Console.WriteLine(index);
                }
                else if (token == "Remove")
                {
                    int startIndex = int.Parse(command[1]);
                    int count = int.Parse(command[2]);
                    if (startIndex >= 0 && startIndex < text.Length && count > startIndex && count < text.Length)//!!
                    {
                        text= text.Remove(startIndex, count);
                        Console.WriteLine(text);
                    }
                    
                }

                line = Console.ReadLine();
            }
        }
    }
}
