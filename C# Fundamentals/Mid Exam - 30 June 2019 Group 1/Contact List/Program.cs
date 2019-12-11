using System;
using System.Linq;

namespace Contact_List
{
    class Program
    {
        static void Main(string[] args)
        {
            var contacts = Console.ReadLine().Split().ToList();
            var command = Console.ReadLine().Split().ToList();

            while (command[0] != "Print")
            {
                if (command[0] == "Add")
                {
                    string contact = command[1];
                    int index = int.Parse(command[2]);
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
                else if (command[0] == "Remove")
                {
                    int index = int.Parse(command[1]);
                    if (index >= 0 && index < contacts.Count)
                    {
                        contacts.RemoveAt(index);
                    }
                }
                else if (command[0] == "Export")
                {
                    int startIndex = int.Parse(command[1]);
                    int count = int.Parse(command[2]);
                    if (startIndex >= 0 && startIndex < contacts.Count - 1)
                    {
                        var print = contacts.Skip(startIndex).Take(count).ToList();
                        Console.WriteLine(string.Join(" ", print));
                    }
                }
                command = Console.ReadLine().Split().ToList();
            }
            if (command[0] == "Print")
            {
                if (command[1]== "Normal")
                {
                    Console.WriteLine($"Contacts: {string.Join(" ",contacts)}");
                }
                else if (command[1]== "Reversed")
                {
                    contacts.Reverse();
                    Console.WriteLine($"Contacts: {string.Join(" ", contacts)}");
                }
            }
        }
    }
}
