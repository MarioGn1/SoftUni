using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Queue_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] requirements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = requirements[0];
            int s = requirements[1];
            int x = requirements[2];

            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).
                ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < s; i++)
            {
                queue.TryDequeue(out int result);
            }

            if (queue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
