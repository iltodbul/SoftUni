using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Easter_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            var giftList = Console.ReadLine().Split().ToList();
            var commands = Console.ReadLine().Split().ToList();

            while (commands[1] != "Money")
            {
                if (commands[0] == "OutOfStock")
                {
                    string gift = commands[1];
                    for (int i = 0; i < giftList.Count; i++)
                    {
                        if (giftList[i]==gift)
                        {
                            giftList[i] = "None";
                        }
                    }
                }
                else if (commands[0] == "Required")
                {
                    string gift = commands[1];
                    int index = int.Parse(commands[2]);
                    if (index>=0&&index<giftList.Count)
                    {
                        giftList[index] = gift;
                    }
                }
                else if (commands[0] == "JustInCase")
                {
                    string gift = commands[1];
                    giftList[giftList.Count - 1] = gift;
                }

                commands = Console.ReadLine().Split().ToList();
            }
            var filtredList = new List<string>();
            foreach (var item in giftList)
            {
                if (item!="None")
                {
                    filtredList.Add(item);
                }
            }
            Console.WriteLine(string.Join(" ",filtredList));
        }
    }
}
