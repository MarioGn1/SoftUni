using System;
using System.Collections.Generic;
using System.Linq;

namespace Set_of_elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            HashSet<string> a = new HashSet<string>();
            HashSet<string> b = new HashSet<string>();

            for (int i = 0; i < sizes.Sum(); i++)
            {
                string curElement = Console.ReadLine();
                if (i < sizes[0])
                {
                    a.Add(curElement);
                    continue;
                }
                b.Add(curElement);
            }
            
            Console.WriteLine(string.Join(' ', a.Intersect(b)));
        }
    }
}
