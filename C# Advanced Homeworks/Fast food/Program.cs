using System;
using System.Collections.Generic;
using System.Linq;

namespace Fast_food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodAmount = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            Queue<int> queue = new Queue<int>(orders);

            Console.WriteLine(queue.Max());

            while (true)
            {
                if (queue.TryPeek(out int result) && foodAmount >= queue.Peek())
                {
                    foodAmount -= queue.Peek();
                    queue.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if (!queue.Any())
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
        }
    }
}
