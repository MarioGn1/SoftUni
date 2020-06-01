using System;
using System.Linq;

namespace Matrix_shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string[,] matrix = new string[size[0], size[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] values = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = values[j];
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string retain = string.Empty;
                bool isTrue = true;
                int row1 = 0;
                int col1 = 0;
                int row2 = 0;
                int col2 = 0;

                string[] curCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                

                if (curCommand.Length != 5)
                {
                    isTrue = false;
                }
                else if (curCommand[0] != "swap")
                {
                    isTrue = false;
                }
                //if (!isTrue)
                //{
                //    Console.WriteLine("Invalid input!");
                //    continue;
                //}
                else
                {
                    row1 = int.Parse(curCommand[1]);
                    col1 = int.Parse(curCommand[2]);
                    row2 = int.Parse(curCommand[3]);
                    col2 = int.Parse(curCommand[4]);
                    if (row1 < 0 || col1 < 0 || row2 < 0 || col2 < 0)
                    {
                        isTrue = false;
                    }
                    else if (row1 > matrix.GetLength(0) - 1 || row2 > matrix.GetLength(0) - 1)
                    {
                        isTrue = false;
                    }
                    else if (col1 > matrix.GetLength(1) - 1 || col2 > matrix.GetLength(1) - 1)
                    {
                        isTrue = false;
                    }
                }

                if (!isTrue)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                else
                {
                    retain = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = retain;
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            Console.Write($"{matrix[i, j]} ");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
