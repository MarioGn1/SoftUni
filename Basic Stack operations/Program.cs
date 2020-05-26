using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Stack_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] requirements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = requirements[0];
            int s = requirements[1];
            int x = requirements[2];

            int [] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).
                ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                stack.Push(numbers[i]);
            }
            
            for (int i = 0; i < s; i++)
            {
                stack.TryPop(out int result);         
            }

            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {                
                Console.WriteLine(stack.Min());
            }
        }
    }
}
