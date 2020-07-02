using System;
using System.Collections.Generic;
using System.Linq;

namespace LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            Stack<int> stack = new Stack<int>();

            int[] queueInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < queueInput.Length; i++)
            {
                queue.Enqueue(queueInput[i]);
            }

            int[] stackInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < stackInput.Length; i++)
            {
                stack.Push(stackInput[i]);
            }

            List<int> sums = new List<int>();

            while ( true )
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine("First lootbox is empty");
                    break;
                }
                if (stack.Count == 0)
                {
                    Console.WriteLine("Second lootbox is empty");
                    break;
                }

                int curSum = stack.Peek() + queue.Peek();
                if (curSum % 2 == 0)
                {
                    stack.Pop();
                    queue.Dequeue();
                    sums.Add(curSum);
                }
                else
                {
                    queue.Enqueue(stack.Pop());                    
                }
            }
            int sum = sums.Sum();
            if (sum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sum}");
            }
        }
    }
}
