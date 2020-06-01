using System;
using System.Linq;

namespace Maximum_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[size[0], size[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] values = Console.ReadLine()
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = values[j];
                }
            }

            long maxSum = 0;
            int maxIndexRaw = 0;
            int maxIndexCol = 0;
            

            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {                
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    long curSum = 0;

                    for (int k = 0; k < 3; k++)
                    {
                        for (int m = 0; m < 3; m++)
                        {
                            curSum += matrix[i + k, j + m];
                        }
                    }
                    if (maxSum < curSum)
                    {
                        maxSum = curSum;
                        maxIndexRaw = i;
                        maxIndexCol = j;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");

            for (int i = maxIndexRaw; i < maxIndexRaw + 3; i++)
            {
                for (int j = maxIndexCol; j < maxIndexCol + 3; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
