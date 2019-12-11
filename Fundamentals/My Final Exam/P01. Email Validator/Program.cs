using System;
using System.Linq;

namespace P01._Email_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();

            string line = Console.ReadLine();

            while (line != "Complete")
            {
                string[] token = line.Split(" ");
                if (line == "Make Upper")
                {
                    email = email.ToUpper();
                    Console.WriteLine(email);
                }
                else if (line == "Make Lower")
                {
                    email = email.ToLower();
                    Console.WriteLine(email);
                }
                else if (token[0] == "GetDomain")
                {
                    int count = int.Parse(token[1]);
                    char[] toPrint = email.TakeLast(count).ToArray();
                    Console.WriteLine(string.Join("", toPrint));

                }
                else if (token[0] == "GetUsername")
                {
                    if (email.Contains('@'))
                    {
                        int indexClomba = email.IndexOf('@');
                        string substring = email.Substring(0, indexClomba);
                        Console.WriteLine(substring);
                    }
                    else
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }

                }
                else if (token[0] == "Replace")
                {
                    //string ch= token[1];
                    //char chr = ch[0];
                    char oldChar = char.Parse(token[1]);
                    char newChar = '-';
                    email = email.Replace(oldChar, newChar);
                    Console.WriteLine(email);

                }
                else if (token[0] == "Encrypt")
                {
                    foreach (var item in email)
                    {
                        Console.Write($"{(int)item} ");
                    }
                    Console.WriteLine();
                }

                line = Console.ReadLine();
            }

        }
    }
}
