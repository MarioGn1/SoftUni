using System;
using System.Collections.Generic;
using System.Linq;

namespace Truck_tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumps = int.Parse(Console.ReadLine());
            Queue<string> pumpsParams = new Queue<string>();


            for (int i = 0; i < pumps; i++)
            {
                pumpsParams.Enqueue(Console.ReadLine());
            }

            int index = 0;

            for (int i = 0; i < pumps; i++)
            {
                int fuel = 0;
                bool isTrue = true;
                Queue<string> iterations = new Queue<string>(pumpsParams);

                for (int j = 0; j < pumps; j++)
                {
                    
                    int[] currentPump = iterations.Peek().Split().Select(int.Parse).ToArray();
                    int curFuel = currentPump[0];
                    int curDistance = currentPump[1];
                    fuel += curFuel;
                    if (fuel >= curDistance)
                    {
                        fuel -= curDistance;
                    }
                    else
                    {
                        isTrue = false;
                        iterations.Clear();
                        break;
                    }
                    iterations.Enqueue(iterations.Dequeue());
                }
                if (isTrue)
                {
                    index = i;
                    break;
                }
                pumpsParams.Enqueue(pumpsParams.Dequeue());
            }

            Console.WriteLine(index);
        }
    }
}
