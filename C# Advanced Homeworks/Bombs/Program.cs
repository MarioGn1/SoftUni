using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bombEf = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] bombCas = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            

            Queue<int> bombEfects = new Queue<int>();
            Stack<int> bombCasings = new Stack<int>();

            for (int i = 0; i < bombEf.Length; i++)
            {
                bombEfects.Enqueue(bombEf[i]);
            }
            for (int i = 0; i < bombCas.Length; i++)
            {
                bombCasings.Push(bombCas[i]);
            }

            int daturaBombs = 0;
            int cherryBombs = 0;
            int smokeDecoyBombs = 0;

            bool isFulfill = false;


            while (bombEfects.Count > 0 && bombCasings.Count > 0)
            {
                int sum = bombEfects.Peek()+bombCasings.Peek();

                if (sum == 40)
                {
                    daturaBombs++;
                    bombEfects.Dequeue();
                    bombCasings.Pop();
                }
                else if (sum == 60)
                {
                    cherryBombs++;
                    bombEfects.Dequeue();
                    bombCasings.Pop();
                }
                else if (sum == 120)
                {
                    smokeDecoyBombs++;
                    bombEfects.Dequeue();
                    bombCasings.Pop();
                }
                else
                {
                    bombCasings.Push(bombCasings.Pop() - 5);
                }
                if (daturaBombs >= 3 && cherryBombs >=3 && smokeDecoyBombs >=3)
                {
                    isFulfill = true;
                    break;
                }
            }

            if (isFulfill)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (bombEfects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEfects)}");
            }
            if (bombCasings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");
            }
            Console.WriteLine($"Cherry Bombs: {cherryBombs}");
            Console.WriteLine($"Datura Bombs: {daturaBombs}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyBombs}");
        }
    }
}
