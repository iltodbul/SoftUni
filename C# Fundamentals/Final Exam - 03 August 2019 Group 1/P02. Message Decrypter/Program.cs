using System;
using System.Text.RegularExpressions;

namespace P02._Message_Decrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"^(?<start_end>\$|%)(?<tag>[A-Z][a-z]{2,})\k<start_end>:\s\[(?<one>\d+)\]\|\[(?<two>\d+)\]\|\[(?<three>\d+)\]\|$");

            int numbersOfLines = int.Parse(Console.ReadLine());
            

            for (int i = 0; i < numbersOfLines; i++)
            {
                string line = Console.ReadLine();
                var message = regex.Match(line);
                if (message.Success)
                {
                    string tag = message.Groups["tag"].Value;
                    char one = (char)int.Parse(message.Groups["one"].Value);
                    char two = (char)int.Parse(message.Groups["two"].Value);
                    char three = (char)int.Parse(message.Groups["three"].Value);
                    Console.WriteLine($"{tag}: {one}{two}{three}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }

            }
        }
    }
}
