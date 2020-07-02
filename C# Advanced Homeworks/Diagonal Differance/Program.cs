using System;
using System.Linq;

namespace Diagonal_Differance
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            for (int i = 0; i < matrixSize; i++)
            {
                int[] command = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = command[j];
                }
            }

            int sumPrimary = 0;
            int sumSecondary = 0;
            for (int i = 0; i < matrixSize; i++)
            {
                sumPrimary += matrix[i, i];
                sumSecondary += matrix[i, matrixSize - 1 - i];
            }

            int differance = Math.Abs(sumPrimary - sumSecondary);
            Console.WriteLine(differance);
        }
    }
}
