using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Wizard_Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> deck = Console.ReadLine().Split(":").ToList();
            var commands = Console.ReadLine().Split().ToList();
            var newDeck = new List<string>();

            while (commands[0] != "Ready")
            {
                if (commands[0] == "Add")
                {
                    string cardToAdd = commands[1];
                    if (deck.Contains(cardToAdd))
                    {
                        newDeck.Add(cardToAdd);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                    
                }
                else if (commands[0] == "Insert")
                {
                    string cardName = commands[1];
                    int index = int.Parse(commands[2]);
                    if (deck.Contains(cardName)&& (index>=0&&index<newDeck.Count))
                    {
                        newDeck.Insert(index, cardName);
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                    
                }
                else if (commands[0] == "Remove")
                {
                    string cardName = commands[1];
                    if (newDeck.Contains(cardName))
                    {
                        newDeck.Remove(cardName);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }

                }
                else if (commands[0] == "Swap")
                {
                    string card1 = commands[1];
                    string card2 = commands[2];
                    int index1 = 0;
                    int index2 = 0;
                    for (int i = 0; i < newDeck.Count; i++)
                    {
                        string currentCard = newDeck[i];
                        if (currentCard == card1)
                        {
                            index1 = i;
                        }
                        if (currentCard == card2)
                        {
                            index2 = i;
                        }
                    }
                    newDeck[index1] = card2;
                    newDeck[index2] = card1;

                }
                else if (commands[0] == "Shuffle")
                {
                    newDeck.Reverse();
                }

                commands = Console.ReadLine().Split().ToList();
            }
            Console.WriteLine(string.Join(" ", newDeck));

        }

    }
}


