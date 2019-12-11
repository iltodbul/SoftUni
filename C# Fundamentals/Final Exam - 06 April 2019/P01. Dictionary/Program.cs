using System;
using System.Collections.Generic;
using System.Linq;

namespace P01._Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordsAndDefinitions = new Dictionary<string, List<string>>();

            string[] text = Console.ReadLine().Split(new string[] { " | ", ": " }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < text.Length; i++)
            {
                string word = text[i];
                string definition = text[i + 1];
                if (!wordsAndDefinitions.ContainsKey(word))
                {
                    wordsAndDefinitions.Add(word, new List<string>());
                    wordsAndDefinitions[word].Add(definition);
                }
                else
                {
                    wordsAndDefinitions[word].Add(definition);
                }

                i++;
            }

            string[] checkWords = Console.ReadLine().Split(" | ");

            for (int k = 0; k < checkWords.Length; k++)
            {
                string currentCheckWord = checkWords[k];
                if (wordsAndDefinitions.ContainsKey(currentCheckWord))
                {
                    Console.WriteLine(currentCheckWord);

                    foreach (var item in wordsAndDefinitions[currentCheckWord].OrderByDescending(x=>x.LongCount()))
                    {
                        Console.WriteLine($"-{item}");
                        
                    }
                }
            }

            string lastCommand = Console.ReadLine();
            if (lastCommand=="End")
            {
                return;
            }
            else if (lastCommand=="List")
            {
                foreach (var item in wordsAndDefinitions.OrderBy(x=>x.Key))
                {
                    Console.Write($"{item.Key} ");
                }
            }
        }
    }
}
