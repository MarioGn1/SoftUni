using System;
using System.Linq;

namespace Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            Lake<int> myLake = new Lake<int>();
            int[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            myLake.AddElements(input);

            Console.WriteLine(string.Join(", ", myLake)); 
        }
    }
}
