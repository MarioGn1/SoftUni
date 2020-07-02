using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int snakeCoordsX = -1;
            int snakeCoordsY = -1;
            int foodEaten = 0;

            char[,] teritory = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                string curRaw = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    if (curRaw[j] == 'S')
                    {
                        snakeCoordsX = i;
                        snakeCoordsY = j;
                    }
                    teritory[i, j] = curRaw[j];
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                int nextStepX = -1;
                int nextStepY = -1;
                switch (command)
                {
                    case "up":
                        nextStepX = snakeCoordsX - 1;
                        nextStepY = snakeCoordsY;
                        break;
                    case "down":
                        nextStepX = snakeCoordsX + 1;
                        nextStepY = snakeCoordsY;
                        break;
                    case "left":
                        nextStepX = snakeCoordsX;
                        nextStepY = snakeCoordsY - 1;
                        break;
                    case "right":
                        nextStepX = snakeCoordsX;
                        nextStepY = snakeCoordsY + 1;
                        break;
                    default:
                        throw new ArgumentException("Invalid operation!");
                }
                if (nextStepX < 0 || nextStepX > size - 1 || nextStepY < 0 || nextStepY > size - 1)
                {
                    teritory[snakeCoordsX, snakeCoordsY] = '.';
                    Console.WriteLine("Game over!");
                    break;
                }

                if (teritory[nextStepX,nextStepY] == '*')
                {
                    foodEaten++;
                    teritory[nextStepX, nextStepY] = 'S';
                    teritory[snakeCoordsX, snakeCoordsY] = '.';
                    snakeCoordsX = nextStepX;
                    snakeCoordsY = nextStepY;
                }
                else if (teritory[nextStepX, nextStepY] == 'B')
                {
                    teritory[nextStepX, nextStepY] = '.';
                    teritory[snakeCoordsX, snakeCoordsY] = '.';
                    for (int i = 0; i < size; i++)
                    {                        
                        for (int j = 0; j < size; j++)
                        {
                            if (teritory[i,j] == 'B')
                            {
                                teritory[i, j] = 'S';
                                snakeCoordsX = i;
                                snakeCoordsY = j;                                
                                break;
                            }                            
                        }
                    }
                }
                else
                {
                    teritory[nextStepX, nextStepY] = 'S';
                    teritory[snakeCoordsX, snakeCoordsY] = '.';
                    snakeCoordsX = nextStepX;
                    snakeCoordsY = nextStepY;
                }
                if (foodEaten == 10)
                {
                    Console.WriteLine("You won! You fed the snake.");
                    break;
                }
            }

            Console.WriteLine($"Food eaten: {foodEaten}");

            for (int i = 0; i < teritory.GetLength(0); i++)
            {
                for (int j = 0; j < teritory.GetLength(1); j++)
                {
                    Console.Write(teritory[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
