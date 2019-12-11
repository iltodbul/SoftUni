using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace P03._The_Isle_of_Man_TT_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"^(?<start_end>[\#\$%\*\&])(?<name>[A-Za-z]+)\k<start_end>=(?<lenght>\d+)!!(?<code>.+)$");

            string text = Console.ReadLine();

            
            bool found = false;
            while (found==false)
            {
                var message = regex.Match(text);
                if (message.Success)
                {
                    string name = message.Groups["name"].Value;
                    int lenght = int.Parse(message.Groups["lenght"].Value);
                    string code = message.Groups["code"].Value;
                    int codeLenght = code.Length;

                    string newCode = string.Empty;

                    if (lenght == codeLenght)
                    {

                        for (int i = 0; i < code.Length; i++)
                        {
                            char currentChar = code[i];
                            char newChar = (char)(currentChar + lenght);
                            newCode += newChar;
                        }
                        Console.WriteLine($"Coordinates found! {name} -> {newCode}");
                        found = true;
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                        text = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                    text = Console.ReadLine();
                }
            }

            
        }
    }
}
