using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Santa_sPresentFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] secondInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> materials = new Stack<int>();
            Queue<int> magicValue = new Queue<int>();

            for (int i = 0; i < firstInput.Length; i++)
            {
                materials.Push(firstInput[i]);
            }
            for (int i = 0; i < secondInput.Length; i++)
            {
                magicValue.Enqueue(secondInput[i]);
            }

            Dictionary<string, int> presents = new Dictionary<string, int>()
            {
                {"Doll", 0},
                {"Wooden train", 0},
                {"Teddy bear", 0},
                {"Bicycle", 0}
            };

            while (materials.Count != 0 && magicValue.Count != 0)
            {
                int magicLevel = materials.Peek() * magicValue.Peek();
                string curPresent = string.Empty;

                if (magicLevel == 150)
                {
                    curPresent = "Doll";
                }
                else if (magicLevel == 250)
                {
                    curPresent = "Wooden train";
                }
                else if (magicLevel == 300)
                {
                    curPresent = "Teddy bear";
                }
                else if (magicLevel == 400)
                {
                    curPresent = "Bicycle";
                }
                if (curPresent != string.Empty)
                {
                    presents[curPresent]++;
                    materials.Pop();
                    magicValue.Dequeue();
                }
                else
                {
                    if (magicLevel < 0)
                    {
                        int sum = materials.Pop() + magicValue.Dequeue();
                        materials.Push(sum);
                    }
                    else if (magicLevel > 0)
                    {
                        magicValue.Dequeue();
                        materials.Push(materials.Pop() + 15);
                    }
                    if (materials.TryPeek(out int resultOne))
                    {
                        if (resultOne == 0)
                        {
                            materials.Pop();
                        }

                    }
                    if (magicValue.TryPeek(out int resultTwo))
                    {
                        if (resultTwo == 0)
                        {
                            magicValue.Dequeue();
                        }

                    }
                }
            }
            bool isSuccess = false;
            if (presents["Doll"] > 0 && presents["Wooden train"] > 0)
            {
                isSuccess = true;
            }
            else if (presents["Teddy bear"] > 0 && presents["Bicycle"] > 0)
            {
                isSuccess = true;
            }
            if (isSuccess)
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }
            if (materials.Count > 0)
            {
                Console.WriteLine($"Materials left: {string.Join(", ", materials)}");
            }
            if (magicValue.Count > 0)
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magicValue)}");
            }

            presents = presents.OrderBy(el => el.Key).ToDictionary(x => x.Key, y => y.Value);

            foreach (var item in presents)
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
    }
}
