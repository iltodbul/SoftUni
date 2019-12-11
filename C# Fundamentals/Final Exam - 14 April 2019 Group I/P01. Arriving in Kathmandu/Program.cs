using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace P01._Arriving_in_Kathmandu
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"^(?<name>[A-Za-z0-9\!\@\#\$\?]+)=(?<lenght>\d+)<<(?<code>.+)$");

            string line = Console.ReadLine();

            while (line!= "Last note")
            {
                var message = regex.Match(line);
                if (message.Success)
                {
                    string name = message.Groups["name"].Value;
                    int lenght = int.Parse(message.Groups["lenght"].Value);
                    string code = message.Groups["code"].Value;
                    int codeLenght = code.Length;
                    string newName = string.Empty;
                    if (codeLenght==lenght)
                    {
                        foreach (var item in name)
                        {
                            if (Char.IsLetter(item))
                            {
                                newName += item;
                            }
                        }
                        if (newName!=string.Empty)
                        {
                            Console.WriteLine($"Coordinates found! {newName} -> {code}");
                        }
                        

                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                    }

                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }

                line = Console.ReadLine();
            }
        }
    }
}
