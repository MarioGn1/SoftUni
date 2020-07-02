using System;
using System.Linq;

namespace Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int raws = int.Parse(Console.ReadLine());

            double[][] jagged = new double[raws][];

            for (int i = 0; i < raws; i++)
            {
                double [] data = Console.ReadLine()
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                jagged[i] = data;
            }
            for (int i = 0; i < raws - 1; i++)
            {
                if (jagged[i].Length == jagged[i+1].Length)
                {
                    for (int j = 0; j < jagged[i].Length; j++)
                    {
                        jagged[i][j] *= 2;
                        jagged[i+1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < jagged[i].Length; j++)
                    {
                        jagged[i][j] /= 2;                        
                    }
                    for (int j = 0; j < jagged[i+1].Length; j++)
                    {
                        jagged[i+1][j] /= 2;
                    }
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] curCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int raw = int.Parse(curCommand[1]);
                int col = int.Parse(curCommand[2]);
                int value = int.Parse(curCommand[3]);

                if (raw >= 0 && raw < raws && col >= 0 && col < jagged[raw].Length)
                {
                    switch (curCommand[0])
                    {
                        case "Add":
                            jagged[raw][col] += value;
                            break;
                        case "Subtract":
                            jagged[raw][col] -= value;
                            break;
                        default:
                            throw new ArgumentException("Invalid operation!");
                    }
                }
            }
            foreach (double [] item in jagged)
            {
                Console.WriteLine(string.Join(' ', item));
            }
        }
    }
}
