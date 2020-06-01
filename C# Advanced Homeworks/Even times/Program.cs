using System;
using System.Collections.Generic;

namespace Even_times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> numbers = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string curNumber = Console.ReadLine();

                if (!numbers.ContainsKey(curNumber))
                {
                    numbers[curNumber] = 1;
                    continue;
                }

                numbers[curNumber]++;
            }

            foreach (var item in numbers)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                    break;
                }
            }
        }
    }
}
