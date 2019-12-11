using System;
using System.Linq;

namespace _3._Easter_Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            var shopList = Console.ReadLine().Split().ToList();
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                var command = Console.ReadLine().Split().ToList();

                if (command[0] == "Include")
                {
                    string shop = command[1];
                    shopList.Add(shop);
                }
                else if (command[0] == "Visit")
                {
                    int count = int.Parse(command[2]);
                    if (count > 0 && count < shopList.Count)
                    {
                        if (command[1] == "first")
                        {
                            shopList = shopList.Skip(count).ToList();
                        }
                        else if (command[1] == "last")
                        {
                            shopList = shopList.Take(shopList.Count - count).ToList();
                        }

                    }
                }
                else if (command[0] == "Prefer")
                {
                    int shopIndex1 = int.Parse(command[1]);
                    int shopIndex2 = int.Parse(command[2]);
                    if (shopIndex1 >= 0 && shopIndex1 < shopList.Count && shopIndex2 >= 0 && shopIndex2 < shopList.Count)
                    {
                        string shop1 = shopList[shopIndex1];
                        string shop2 = shopList[shopIndex2];
                        shopList[shopIndex2] = shop1;
                        shopList[shopIndex1] = shop2;

                    }

                }
                else if (command[0] == "Place")
                {
                    string shop = command[1];
                    int index = int.Parse(command[2]);
                    int newIndex = index + 1;
                    if (index >= 0 && index < shopList.Count && newIndex >= 0 && newIndex < shopList.Count)
                    {
                        shopList.Insert(newIndex, shop);
                    }
                }
            }
            Console.WriteLine($"Shops left:\n{string.Join(" ",shopList)}");
            //Console.WriteLine(string.Join(" ",shopList));
        }
    }
}
