using System;
using System.Collections.Generic;

namespace Count_simbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> charNumbers = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                
                if (!charNumbers.ContainsKey(text[i]))
                {
                    charNumbers[text[i]] = 1;
                    continue;
                }

                charNumbers[text[i]]++;
            }

            foreach (var item in charNumbers)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
