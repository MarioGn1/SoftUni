using System;
using System.Collections.Generic;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> nameLenghtCompare = (name, givenLength) => name.ToCharArray().Sum(el => el) >= givenLength;
            Func<List<string>, Func<string, int, bool>, int, string> nameSortation = (x, y, z) => x.Find(el => y(el, z));

            int num = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToList();            
            
            Console.WriteLine(nameSortation(names, nameLenghtCompare, num));
        }
    }
}
