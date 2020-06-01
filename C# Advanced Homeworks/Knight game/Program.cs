using System;


namespace Knight_game
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());


            char[,] field = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                string curRow = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    field[i, j] = curRow[j];
                }
            }
            if (size < 3)
            {
                Console.WriteLine(0);
                return;
            }

            int counter = 0;
            while (true)
            {
                int maxTargets = 0;
                int curMaxTargetsRaw = -1;
                int curMaxTargetsCol = -1;
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (field[i, j] == 'K')
                        {
                            int curKnightTargets = CheckForKnights(field, i, j);
                            if (curKnightTargets > maxTargets)
                            {
                                maxTargets = curKnightTargets;
                                curMaxTargetsRaw = i;
                                curMaxTargetsCol = j;
                            }
                        }
                    }
                }
                if (maxTargets == 0)
                {
                    break;
                }
                field[curMaxTargetsRaw, curMaxTargetsCol] = '0';
                counter++;
            }

            
            Console.WriteLine(counter);
        }

        private static int CheckForKnights(char[,] field, int raw, int col)
        {
            int counter = 0;
            if (raw - 2 >= 0 && col + 1 < field.GetLength(1))
            {
                if (field[raw - 2, col + 1] == 'K')
                {                    
                    counter++;
                }
            }
            if (raw - 1 >= 0 && col + 2 < field.GetLength(1))
            {
                if (field[raw - 1, col + 2] == 'K')
                {                    
                    counter++;
                }
            }
            if (raw + 1 < field.GetLength(0) && col + 2 < field.GetLength(1))
            {
                if (field[raw + 1, col + 2] == 'K')
                {                    
                    counter++;
                }
            }
            if (raw + 2 < field.GetLength(0) && col + 1 < field.GetLength(1))
            {
                if (field[raw + 2, col + 1] == 'K')
                {                    
                    counter++;
                }
            }
            if (raw + 2 < field.GetLength(0) && col - 1 >= 0)
            {
                if (field[raw + 2, col - 1] == 'K')
                {                    
                    counter++;
                }
            }
            if (raw + 1 < field.GetLength(0) && col - 2 >= 0)
            {
                if (field[raw + 1, col - 2] == 'K')
                {                    
                    counter++;
                }
            }
            if (raw - 1 >= 0 && col - 2 >= 0)
            {
                if (field[raw - 1, col - 2] == 'K')
                {                    
                    counter++;
                }
            }
            if (raw - 2 >= 0 && col - 1 >= 0)
            {
                if (field[raw - 2, col - 1] == 'K')
                {                    
                    counter++;
                }
            }
            return counter;
        }
    }
}
