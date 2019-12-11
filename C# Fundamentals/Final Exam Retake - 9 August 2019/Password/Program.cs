using System;
using System.Text.RegularExpressions;

namespace P02.Password
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"^(?<start_end>.+)>(?<one>\d{3})\|(?<two>[a-z]{3})\|(?<three>[A-Z]{3})\|(?<four>[^<>]{3})<\k<start_end>$");
            int loops = int.Parse(Console.ReadLine());

            for (int i = 0; i < loops; i++)
            {
                string line = Console.ReadLine();
                MatchCollection password = regex.Matches(line);
                if (password.Count > 0)
                {
                    foreach (Match item in password)
                    {
                        string one = item.Groups["one"].Value;
                        string two = item.Groups["two"].Value;
                        string three = item.Groups["three"].Value;
                        string four = item.Groups["four"].Value;

                        Console.WriteLine($"Password: { one + two + three + four}");
                    }
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }

            }

        }
    }
}
