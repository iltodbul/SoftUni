using System;
using System.Linq;

namespace Contact_List
{
    class Program
    {
        static void Main(string[] args)
        {
            var contacts = Console.ReadLine().Split().ToList();
            var commands = Console.ReadLine().Split().ToList();

            while (commands[0] != "Print")
            {
                if (commands[0] == "Add")
                {
                    string contact = commands[1];
                    int index = int.Parse(commands[2]);
                    if (index >= 0 && index < contacts.Count)
                    {
                        if (contacts.Contains(contact))
                        {
                            contacts.Insert(index, contact);
                        }
                        else
                        {
                            contacts.Add(contact);
                        }
                    }

                }
                else if (commands[0] == "Remove")
                {
                    int index = int.Parse(commands[1]);
                    if (index >= 0 && index < contacts.Count)
                    {
                        contacts.RemoveAt(index);
                    }
                }
                else if (commands[0] == "Export")
                {
                    int startIndex = int.Parse(commands[1]);
                    int count = int.Parse(commands[2]);
                    if (startIndex >= 0 && startIndex < contacts.Count - 1)
                    {
                        var print = contacts.Skip(startIndex).Take(count).ToList();
                        Console.WriteLine(string.Join(" ", print));
                    }
                }
                commands = Console.ReadLine().Split().ToList();
            }
            if (commands[0] == "Print")
            {
                if (commands[1]== "Normal")
                {
                    Console.WriteLine($"Contacts: {string.Join(" ",contacts)}");
                }
                else if (commands[1]== "Reversed")
                {
                    contacts.Reverse();
                    Console.WriteLine($"Contacts: {string.Join(" ", contacts)}");
                }
            }
        }
    }
}
