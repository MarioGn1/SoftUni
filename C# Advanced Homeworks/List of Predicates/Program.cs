using System;
using System.Collections.Generic;
using System.Linq;

namespace List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            //int[] dividends = new int[n];
            List<int> targetNums = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                Predicate<int[]> divisionSort = x => x.All(m => i % m == 0);

                if (divisionSort(dividers))
                {
                    targetNums.Add(i);
                }
                //dividends[i] = i + 1;
            }

            //Func<int[], int[], int[]> divisionSort = (x, y) => x.Where(elX => y.All(elY => elX % elY == 0)).ToArray();

            Console.WriteLine(string.Join(' ', targetNums));
        }
    }
}
