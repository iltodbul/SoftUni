using System;
using System.Text.RegularExpressions;
using System.Text;

namespace MessageEncrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(?<start_end>\*|@)(?<tag>[A-Z]{1}[a-z]{2,})\k<start_end>: \[(?<one>[A-Za-z]{1})\]\|\[(?<two>[A-Za-z]{1})\]\|\[(?<three>[A-Za-z]{1})\]\|$");

            int NumberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < NumberOfLines; i++)
            {
                string text = Console.ReadLine();
                var message = regex.Match(text);
                if (message.Success)
                {
                    string tag = message.Groups["tag"].Value;
                    int one = message.Groups["one"].Value[0];
                    int two = message.Groups["two"].Value[0];
                    int three = message.Groups["three"].Value[0];

                    Console.WriteLine($"{tag}: {one} {two} {three}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }

            }
        }
    }
}
