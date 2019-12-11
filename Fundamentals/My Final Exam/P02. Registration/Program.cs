using System;
using System.Text.RegularExpressions;

namespace P02._Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"^U\$(?<username>[A-Z][a-z]{2,})U\$P\@\$(?<password>[A-Za-z]{5,}\d+)P\@\$$");

            int numberOfimputs = int.Parse(Console.ReadLine());
            int countSuccess = 0;

            for (int i = 0; i < numberOfimputs; i++)
            {
                string text = Console.ReadLine();

                var mach = regex.Match(text);

                if (mach.Success)
                {
                    countSuccess++;

                    string username = mach.Groups["username"].Value;
                    string password = mach.Groups["password"].Value;

                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {username}, Password: {password}");
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }

            }

            Console.WriteLine($"Successful registrations: {countSuccess}");
        }
    }
}
