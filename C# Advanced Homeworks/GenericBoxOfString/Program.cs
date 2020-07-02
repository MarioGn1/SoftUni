using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace GenericBoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> colection = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var curElement = (Console.ReadLine());
                colection.Add(curElement);
            }
            string valueToCompare = (Console.ReadLine());

            int count = Box<string>.CompareCount(colection, valueToCompare);

            Console.WriteLine(count);
            

            //int m = int.Parse(Console.ReadLine());
            //Box<int> inList = new Box<int>();

            //for (int i = 0; i < m; i++)
            //{
            //    inList.AddObject(int.Parse(Console.ReadLine()));
            //}

            //int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //inList.Swap( indexes[0], indexes[1]);

            //Console.WriteLine((Box<int>)inList);
        }
    }
}
