using System;

namespace Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int comandsCount = int.Parse(Console.ReadLine());

            int playerCoordinatesX = -1;
            int playerCoordinatesY = -1;

            char[,] field = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                string curRaw = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    if (curRaw[j] == 'f')
                    {
                        playerCoordinatesX = i;
                        playerCoordinatesY = j;
                    }
                    field[i, j] = curRaw[j];
                }
            }
            bool isFinish = false;
            while (comandsCount > 0)
            {
                string curCommand = Console.ReadLine();

                switch (curCommand)
                {
                    case "up":
                        (playerCoordinatesX, playerCoordinatesY, isFinish) = MoveUp(field, playerCoordinatesX, playerCoordinatesY, isFinish);
                        break;
                    case "down":
                        (playerCoordinatesX, playerCoordinatesY, isFinish) = MoveDown(field, playerCoordinatesX, playerCoordinatesY, isFinish);
                        break;
                    case "left":
                        (playerCoordinatesX, playerCoordinatesY, isFinish) = MoveLeft(field, playerCoordinatesX, playerCoordinatesY, isFinish);
                        break;
                    case "right":
                        (playerCoordinatesX, playerCoordinatesY, isFinish) = MoveRight(field, playerCoordinatesX, playerCoordinatesY, isFinish);
                        break;
                    default:
                        throw new ArgumentException("Invalid operation!");
                }
                if (isFinish)
                {
                    break;
                }
                comandsCount--;
            }
            if (isFinish)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static (int playerCoordinatesX, int playerCoordinatesY, bool isFinish) MoveRight(char[,] field, int playerCoordinatesX, int playerCoordinatesY, bool isFinish)
        {
            int nextStepX = playerCoordinatesX;
            int nextStepY = playerCoordinatesY + 1;

            nextStepY = EdgeFieldRight(field, nextStepY);
            if (field[nextStepX, nextStepY] == 'B')
            {
                nextStepY++;
                nextStepY = EdgeFieldRight(field, nextStepY);

            }
            else if (field[nextStepX, nextStepY] == 'T')
            {
                nextStepY = playerCoordinatesY;
            }
            if (field[nextStepX, nextStepY] == 'F')
            {
                isFinish = true;
            }

            field[nextStepX, nextStepY] = 'f';
            field[playerCoordinatesX, playerCoordinatesY] = '-';
            return (nextStepX, nextStepY, isFinish);
        }

        private static int EdgeFieldRight(char[,] field, int nextStepY)
        {
            if (nextStepY > field.GetLength(0) - 1)
            {
                nextStepY = 0;
            }

            return nextStepY;
        }

        private static (int playerCoordinatesX, int playerCoordinatesY, bool isFinish) MoveLeft(char[,] field, int playerCoordinatesX, int playerCoordinatesY, bool isFinish)
        {
            int nextStepX = playerCoordinatesX;
            int nextStepY = playerCoordinatesY - 1;

            nextStepY = EdgeFieldLeft(field, nextStepY);
            if (field[nextStepX, nextStepY] == 'B')
            {
                nextStepY--;
                nextStepY = EdgeFieldLeft(field, nextStepY);

            }
            else if (field[nextStepX, nextStepY] == 'T')
            {
                nextStepY = playerCoordinatesY;
            }
            if (field[nextStepX, nextStepY] == 'F')
            {
                isFinish = true;
            }

            field[nextStepX, nextStepY] = 'f';
            field[playerCoordinatesX, playerCoordinatesY] = '-';
            return (nextStepX, nextStepY, isFinish);
        }

        private static int EdgeFieldLeft(char[,] field, int nextStepY)
        {
            if (nextStepY < 0)
            {
                nextStepY = field.GetLength(1) - 1;
            }

            return nextStepY;
        }

        private static (int playerCoordinatesX, int playerCoordinatesY, bool isFinish) MoveDown(char[,] field, int playerCoordinatesX, int playerCoordinatesY, bool isFinish)
        {
            int nextStepX = playerCoordinatesX + 1;
            int nextStepY = playerCoordinatesY;

            nextStepX = EdgeFieldDown(field, nextStepX);
            if (field[nextStepX, nextStepY] == 'B')
            {
                nextStepX++;
                nextStepX = EdgeFieldDown(field, nextStepX);

            }
            else if (field[nextStepX, nextStepY] == 'T')
            {
                nextStepX = playerCoordinatesX;
            }
            if (field[nextStepX, nextStepY] == 'F')
            {
                isFinish = true;
            }

            field[nextStepX, nextStepY] = 'f';
            field[playerCoordinatesX, playerCoordinatesY] = '-';
            return (nextStepX, nextStepY, isFinish);
        }

        private static int EdgeFieldDown(char[,] field, int nextStepX)
        {
            if (nextStepX > field.GetLength(0) - 1)
            {
                nextStepX = 0;
            }

            return nextStepX;
        }

        private static (int playerCoordinatesX, int playerCoordinatesY, bool isFinish) MoveUp(char[,] field, int playerCoordinatesX, int playerCoordinatesY, bool isFinish)
        {
            int nextStepX = playerCoordinatesX - 1;
            int nextStepY = playerCoordinatesY;

            nextStepX = EdgeFieldUp(field, nextStepX);
            if (field[nextStepX, nextStepY] == 'B')
            {
                nextStepX--;
                nextStepX = EdgeFieldUp(field, nextStepX);

            }
            else if (field[nextStepX, nextStepY] == 'T')
            {
                nextStepX = playerCoordinatesX;
            }
            if (field[nextStepX, nextStepY] == 'F')
            {
                isFinish = true;
            }

            field[nextStepX, nextStepY] = 'f';
            field[playerCoordinatesX, playerCoordinatesY] = '-';
            return (nextStepX, nextStepY, isFinish);

        }

        private static int EdgeFieldUp(char[,] field, int nextStepX)
        {
            if (nextStepX < 0)
            {
                nextStepX = field.GetLength(0) - 1;
            }

            return nextStepX;
        }
    }
}
