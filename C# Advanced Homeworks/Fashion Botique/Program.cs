using System;
using System.Collections.Generic;
using System.Linq;

namespace Fashion_Botique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clotes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int capacity = int.Parse(Console.ReadLine());

            Stack<int> clotesArrangement = new Stack<int>(clotes);

            int rackCounter = 0;
            int capCounter = 0;
            while (clotesArrangement.Any())
            {
                if (capCounter+clotesArrangement.Peek() < capacity)
                {
                    capCounter += clotesArrangement.Pop();

                }
                else if (capCounter + clotesArrangement.Peek() == capacity)
                {
                    capCounter = 0;
                    clotesArrangement.Pop();
                    rackCounter++;
                }
                else
                {
                    capCounter = clotesArrangement.Pop();
                    rackCounter++;
                }
            }
            if (capCounter > 0)
            {
                rackCounter++;
            }
            Console.WriteLine(rackCounter);
        }
    }
}
