using System;
using System.Linq;

namespace Action_point
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Action<string> print = message => Console.WriteLine(message);
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                print(input[i]);
            }
        }
    }
}
