using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Lootbox
{
    class StartUp
    {
        static void Main()
        {
            List<int> firstBox = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var secondInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var secondBox = new Stack<int>(secondInput);

            var collection = new List<int>();

            while (firstBox.Any() && secondBox.Any())
            {
                int currentFirstBox = firstBox[0];
                int currentSecondBox = secondBox.Peek();
                int sum = currentFirstBox + currentSecondBox;

                if (sum % 2 == 0)
                {
                    collection.Add(sum);
                    firstBox.RemoveAt(0);
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Add(currentSecondBox);
                    secondBox.Pop();
                }
            }

            if (!firstBox.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (!secondBox.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (collection.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {collection.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {collection.Sum()}");
            }
        }
    }
}
