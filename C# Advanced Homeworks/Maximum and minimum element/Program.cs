using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_and_minimum_element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] query = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                switch (query[0])
                {
                    case 1:
                        stack.Push(query[1]);
                        break;
                    case 2:
                        stack.TryPop(out int result);
                        break;
                    case 3:
                        if (stack.Any())
                        {
                            Console.WriteLine(stack.Max());
                        }
                        break;
                    case 4:
                        if (stack.Any())
                        {
                            Console.WriteLine(stack.Min());
                        }
                        break;
                    default:
                        throw new ArgumentException("Unknown argument!");
                }
            }
            
            Console.WriteLine(string.Join(", ", stack));
            
        }
    }
}
