using System;
using System.Linq;

namespace PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int presents = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());

            int santaCoordinatesX = -1;
            int santaCoordinatesY = -1;

            char[,] houses = new char[size, size];
            int goodKids = 0;
            int happyGoodKids = 0;

            for (int i = 0; i < size; i++)
            {
                char[] curRaw = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int j = 0; j < size; j++)
                {
                    if (curRaw[j] == 'S')
                    {
                        santaCoordinatesX = i;
                        santaCoordinatesY = j;
                    }
                    else if (curRaw[j] == 'V')
                    {
                        goodKids++;
                    }

                    houses[i, j] = curRaw[j];
                }
            }
            
            string curCommand;
            while ((curCommand = Console.ReadLine()) != "Christmas morning" && presents > 0)
            {
                int santaStepX = -1;
                int santaStepY = -1;

                switch (curCommand)
                {
                    case "up":
                        santaStepX = santaCoordinatesX - 1;
                        santaStepY = santaCoordinatesY;
                        SantaActions(ref presents, santaCoordinatesX, santaCoordinatesY, houses, ref goodKids, ref happyGoodKids, santaStepX, santaStepY);
                        break;
                    case "down":
                        santaStepX = santaCoordinatesX + 1;
                        santaStepY = santaCoordinatesY;
                        SantaActions(ref presents, santaCoordinatesX, santaCoordinatesY, houses, ref goodKids, ref happyGoodKids, santaStepX, santaStepY);
                        break;
                    case "left":
                        santaStepX = santaCoordinatesX ;
                        santaStepY = santaCoordinatesY - 1;
                        SantaActions(ref presents, santaCoordinatesX, santaCoordinatesY, houses, ref goodKids, ref happyGoodKids, santaStepX, santaStepY);
                        break;
                    case "right":
                        santaStepX = santaCoordinatesX ;
                        santaStepY = santaCoordinatesY + 1;
                        SantaActions(ref presents, santaCoordinatesX, santaCoordinatesY, houses, ref goodKids, ref happyGoodKids, santaStepX, santaStepY);
                        break;
                    default:
                        throw new ArgumentException("Invalid operation!");
                }
                santaCoordinatesX = santaStepX;
                santaCoordinatesY = santaStepY;
            }

            if (presents == 0)
            {
                Console.WriteLine("Santa ran out of presents!");
            }
            for (int i = 0; i < houses.GetLength(0); i++)
            {
                for (int j = 0; j < houses.GetLength(1); j++)
                {
                    Console.Write($"{houses[i, j]} ");
                }
                Console.WriteLine();
            }
            if (goodKids == 0)
            {
                Console.WriteLine($"Good job, Santa! {happyGoodKids} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {goodKids} nice kid/s.");
            }
        }

        private static void SantaActions(ref int presents, int santaCoordinatesX, int santaCoordinatesY, char[,] houses, ref int goodKids, ref int happyGoodKids, int santaStepX, int santaStepY)
        {
            if (houses[santaStepX, santaStepY] == 'V')
            {
                PresentsDistributor(ref presents, ref goodKids, ref happyGoodKids);
            }
            else if (houses[santaStepX, santaStepY] == 'C')
            {
                if (houses[santaStepX, santaStepY - 1] == 'X')
                {
                    presents--;
                }
                else if (houses[santaStepX, santaStepY - 1] == 'V')
                {
                    PresentsDistributor(ref presents, ref goodKids, ref happyGoodKids);
                }
                houses[santaStepX, santaStepY - 1] = '-';

                if (houses[santaStepX, santaStepY + 1] == 'X' && presents > 0)
                {
                    presents--;
                }
                else if (houses[santaStepX, santaStepY + 1] == 'V' && presents > 0)
                {
                    PresentsDistributor(ref presents, ref goodKids, ref happyGoodKids);
                }
                houses[santaStepX, santaStepY + 1] = '-';

                if (houses[santaStepX - 1, santaStepY] == 'X' && presents > 0)
                {
                    presents--;
                }
                else if (houses[santaStepX - 1, santaStepY] == 'V' && presents > 0)
                {
                    PresentsDistributor(ref presents, ref goodKids, ref happyGoodKids);
                }
                houses[santaStepX - 1, santaStepY] = '-';

                if (houses[santaStepX + 1, santaStepY] == 'X' && presents > 0)
                {
                    presents--;
                }
                else if (houses[santaStepX + 1, santaStepY] == 'V' && presents > 0)
                {
                    PresentsDistributor(ref presents, ref goodKids, ref happyGoodKids);
                }
                houses[santaStepX + 1, santaStepY] = '-';
            }
            houses[santaStepX, santaStepY] = 'S';
            houses[santaCoordinatesX, santaCoordinatesY] = '-';
        }

        private static void PresentsDistributor(ref int presents, ref int goodKids, ref int happyGoodKids)
        {
            goodKids--;
            happyGoodKids++;
            presents--;
        }
    }
}
