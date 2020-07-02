using System;
using System.Linq;

namespace Predicate_for_names
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string[], int, string[]> nameLenghtSorting = (string[] x, int y) => x.Where(el => el.Length <= y).ToArray();

            int lenght = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(string.Join(Environment.NewLine, nameLenghtSorting(names, lenght)));
        }
    }
}
