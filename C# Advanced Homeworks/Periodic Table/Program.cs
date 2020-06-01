using System;
using System.Collections.Generic;

namespace Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> set = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] curElements = Console.ReadLine().Split();

                foreach (var item in curElements)
                {
                    set.Add(item);
                }
            }
            Console.WriteLine(string.Join(' ', set));
        }
    }
}
