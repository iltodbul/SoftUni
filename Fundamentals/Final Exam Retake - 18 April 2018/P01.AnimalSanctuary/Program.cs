using System;
using System.Text.RegularExpressions;

namespace P01.AnimalSanctuary
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"n:(?<name>[^;]+);t:(?<kind>[^;]+);c--(?<country>\w+\s?\w*\s?\w*\s?\w*\s?\w*\s?\w*)$");
            int numberOfLines = int.Parse(Console.ReadLine());
            int weight = 0;
            for (int i = 0; i < numberOfLines; i++)
            {
                string text = Console.ReadLine();
                Match match = regex.Match(text);

                if (match.Success)
                {
                    string cryptedName = match.Groups["name"].Value;
                    string cryptedKind = match.Groups["kind"].Value;
                    string country = match.Groups["country"].Value;

                    string name = "";
                    string kind = "";

                    foreach (var item in cryptedName)
                    {
                        if (Char.IsDigit(item))
                        {
                            weight += int.Parse(item.ToString());
                        }
                        else if (Char.IsLetter(item)||item==' ')
                        {
                            name += item;
                        }
                    }
                    foreach (var item in cryptedKind)
                    {
                        if (Char.IsDigit(item))
                        {
                            weight += int.Parse(item.ToString());
                        }
                        else if (Char.IsLetter(item) || item==' ')
                        {
                            kind += item;
                        }
                    }

                    Console.WriteLine($"{name.Trim()} is a {kind.Trim()} from {country.Trim()}");
                }
            }

            Console.WriteLine($"Total weight of animals: {weight}KG");
        }
    }
}
