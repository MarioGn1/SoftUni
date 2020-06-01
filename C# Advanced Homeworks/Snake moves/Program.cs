using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake_moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string snake = Console.ReadLine();
            Queue<char> snakeParts = new Queue<char>(snake);
            char[,] matrix = new char[size[0], size[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i%2 == 0)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        snakeParts.Enqueue(snakeParts.Peek());
                        matrix[i, j] = snakeParts.Dequeue();
                    }
                }
                else
                {
                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        snakeParts.Enqueue(snakeParts.Peek());
                        matrix[i, j] = snakeParts.Dequeue();
                    }
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }
                Console.WriteLine();
            }
        }
    }
}
