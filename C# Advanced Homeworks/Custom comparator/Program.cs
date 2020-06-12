using System;
using System.Linq;

namespace Custom_comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            //Func<int[], int[]> sortEvenNums = x => x.OrderBy(y => y % 2 != 0).ThenBy(z => z % 2 == 0).ThenBy(n => n).ToArray();

            Array.Sort(numArr, (x, y) =>
            {
                int result = 0;
                if (x % 2 == 0 && y % 2 != 0)
                {
                    result = -1;
                }
                else if (x % 2 != 0 && y % 2 == 0)
                {
                    result = 1;
                }
                else
                {
                    result = x - y;
                }
                return result;
            });

            Console.WriteLine(string.Join(' ', numArr));
        }
    }
}
