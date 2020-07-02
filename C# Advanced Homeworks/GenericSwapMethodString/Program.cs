using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> inList = new List<int>();
            
            for (int i = 0; i < n; i++)
            {
                inList.Add(int.Parse(Console.ReadLine()));
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            ListSwap<int>.SwapedElements(inList, indexes[0], indexes[1]);

            foreach (var item in inList)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }

    }
}
