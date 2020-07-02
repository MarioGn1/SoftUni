using System;
using System.Collections.Generic;
using System.Linq;

namespace DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> male = new Stack<int>();
            Queue<int> female = new Queue<int>();

            int[] stackInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] queueInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < queueInput.Length; i++)
            {
                female.Enqueue(queueInput[i]);
            }


            for (int i = 0; i < stackInput.Length; i++)
            {
                male.Push(stackInput[i]);
            }
            int matches = 0;
            while (male.Count > 0 && female.Count > 0)
            {
                int curMale = male.Peek();
                int curFemale = female.Peek();

                if (curMale <= 0)
                {
                    male.Pop();
                    continue;
                }
                if (curFemale <= 0)
                {
                    female.Dequeue();
                    continue;
                }


                if (curFemale == curMale)
                {
                    if (curMale % 25 == 0)
                    {
                        male.Pop();
                        if (male.Count > 0)
                        {
                            male.Pop();
                        }

                        female.Dequeue();
                        if (female.Count > 0)
                        {
                            female.Dequeue();
                        }
                        continue;
                    }
                    matches++;
                    male.Pop();
                    female.Dequeue();

                }
                else
                {
                    if (curMale % 25 == 0)
                    {
                        male.Pop();
                        if (male.Count > 0)
                        {
                            male.Pop();
                        }
                        continue;
                    }
                    else if (curFemale % 25 == 0)
                    {
                        female.Dequeue();
                        if (female.Count > 0)
                        {
                            female.Dequeue();
                        }
                        continue;
                    }
                    female.Dequeue();
                    male.Push(male.Pop() - 2);
                }
            }

            Console.WriteLine($"Matches: {matches}");

            if (male.Count == 0)
            {
                Console.WriteLine("Males left: none");
            }
            else
            {
                Console.WriteLine($"Males left: {string.Join(", ", male)}");
            }
            if (female.Count == 0)
            {
                Console.WriteLine("Females left: none");
            }
            else
            {
                Console.WriteLine($"Females left: {string.Join(", ", female)}");
            }
        }
    }
}
