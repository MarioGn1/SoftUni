using System;
using System.Linq;

namespace Find_even_or_odds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> type = t => 
            {
                return t % 2 == 0;
            };
            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();

            for (int i = range[0]; i <= range[1]; i++)
            {
                if (command == "even")
                {
                    if (type(i))
                    {
                        Console.Write($"{i} ");
                    }
                }
                else if (command == "odd")
                {
                    if (!type(i))
                    {
                        Console.Write($"{i} ");
                    }
                }                
            }
            Console.WriteLine();
        }
    }
}
