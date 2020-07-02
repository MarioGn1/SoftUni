using System;
using System.Linq;

namespace Custom_min_function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> smallestNum = x => x[0];

            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).OrderBy(x => x).ToArray();

            Console.WriteLine(smallestNum(input));
        }
    }
}
