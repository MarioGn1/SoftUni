using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            Queue<string> carsQueue = new Queue<string>();

            int counter = 0;

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command != "green")
                {
                    carsQueue.Enqueue(command);
                }
                else
                {                    
                    Queue<char> passed = new Queue<char>();
                    if (carsQueue.Count>0)
                    {
                        passed = new Queue<char>(carsQueue.Peek());
                    }                    

                    if (passed.Count > 0)
                    {
                        for (int j = 0; j < greenLight; j++)
                        {
                            if (passed.Count > 0)
                            {
                                passed.Dequeue();
                            }
                            else
                            {
                                counter++;
                                carsQueue.Dequeue();
                                if (carsQueue.Count > 0)
                                {
                                    passed = new Queue<char>(carsQueue.Peek());
                                    passed.Dequeue();                                    
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        if (passed.Count == 0 && carsQueue.Count == 0)
                        {
                            continue;
                        }
                        for (int j = 0; j < freeWindow; j++)
                        {
                            if (passed.Count > 0)
                            {
                                passed.Dequeue();
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (passed.Count > 0)
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{carsQueue.Peek()} was hit at {passed.Peek()}.");
                            return;
                        }
                        else
                        {
                            counter++;
                        }
                    }                    
                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{counter} total cars passed the crossroads.");
        }
    }
}
