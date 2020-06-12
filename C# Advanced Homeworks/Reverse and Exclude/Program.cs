using System;
using System.Linq;

namespace Reverse_and_Exclude
{
    class Program
    {

        static void Main(string[] args)
        {
            Func<int[], int, int[]> divisibleSorting = (int[] x, int y) => x.Where(el => el % y != 0).Reverse().ToArray();

            int[] inputNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int divider = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Join(' ', divisibleSorting(inputNums, divider)));
        }
    }
}
