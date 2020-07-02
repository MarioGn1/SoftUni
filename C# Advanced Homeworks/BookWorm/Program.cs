using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookWorm
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int size = int.Parse(Console.ReadLine());

            List<char> actionString = new List<char>(input);


            int playerCoordinatesX = -1;
            int playerCoordinatesY = -1;

            char[,] field = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                string curRaw = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    if (curRaw[j] == 'P')
                    {
                        playerCoordinatesX = i;
                        playerCoordinatesY = j;
                    }
                    field[i, j] = curRaw[j];
                }
            }
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                int nextStepX = -1;
                int nextStepY = -1;
                switch (command)
                {
                    case "up":
                        nextStepX = playerCoordinatesX - 1;
                        nextStepY = playerCoordinatesY;
                        break;
                    case "down":
                        nextStepX = playerCoordinatesX + 1;
                        nextStepY = playerCoordinatesY;
                        break;
                    case "left":
                        nextStepX = playerCoordinatesX;
                        nextStepY = playerCoordinatesY - 1;
                        break;
                    case "right":
                        nextStepX = playerCoordinatesX;
                        nextStepY = playerCoordinatesY + 1;
                        break;
                    default:
                        throw new ArgumentException("Invalid operation!");
                }
                if (nextStepX < 0 || nextStepX > size - 1 || nextStepY < 0 || nextStepY > size - 1)
                {
                    if (actionString.Count > 0)
                    {
                        actionString.RemoveAt(actionString.Count - 1);
                    }
                    continue;
                }
                if (char.IsLetter(field[nextStepX, nextStepY]))
                {
                    actionString.Add(field[nextStepX, nextStepY]);                    
                }
                field[playerCoordinatesX, playerCoordinatesY] = '-';
                field[nextStepX, nextStepY] = 'P';
                playerCoordinatesX = nextStepX;
                playerCoordinatesY = nextStepY;
            }

            string finalState = new string(actionString.ToArray());
            Console.WriteLine(finalState);
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
