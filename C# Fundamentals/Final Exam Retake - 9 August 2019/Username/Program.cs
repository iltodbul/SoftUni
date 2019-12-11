using System;
using System.Linq;

namespace P01.Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string[] line = Console.ReadLine().Split().ToArray();

            while (line[0] != "Sign")
            {
                if (line[0] == "Case")
                {
                    string type = line[1];
                    if (type == "lower")
                    {
                        username = username.ToLower();
                        Console.WriteLine(username);
                    }
                    else if (type == "upper")
                    {
                        username = username.ToUpper();
                        Console.WriteLine(username);
                    }
                }
                else if (line[0] == "Reverse")
                {
                    int startIndex = int.Parse(line[1]);
                    int endIndex = int.Parse(line[2]);
                    if (startIndex >= 0 && startIndex < username.Length && endIndex > startIndex && endIndex <= username.Length + 1)
                    {
                        int lenght = endIndex + 1 - startIndex;
                        char[] substring = username.Substring(startIndex, lenght).ToCharArray();
                        Array.Reverse(substring);

                        Console.WriteLine(string.Join("", substring));
                    }


                }
                else if (line[0] == "Cut")
                {
                    string subs = line[1];
                    if (username.Contains(subs))
                    {
                        int start = username.IndexOf(subs);
                        int lenght = subs.Length;
                        username = username.Remove(start, lenght);
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The word {username} doesn't contain {subs}.");
                    }
                }
                else if (line[0] == "Replace")
                {
                    string temp = line[1];
                    char toReplace = temp[0];
                    username = username.Replace(toReplace, '*');
                    Console.WriteLine(username);
                }
                else if (line[0] == "Check")
                {
                    string temp = line[1];
                    char isValid = temp[0];
                    if (username.Contains(isValid))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {isValid}.");
                    }
                }

                line = Console.ReadLine().Split().ToArray();
            }
        }
    }
}
