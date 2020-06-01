using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] curClotes = Console.ReadLine()
                    .Split(new string[] { ",", " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string color = curClotes[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }
                for (int j = 1; j < curClotes.Length; j++)
                {
                    string curWear = curClotes[j];
                    if (!wardrobe[curClotes[0]].ContainsKey(curWear))
                    {
                        wardrobe[color][curWear] = 1;
                        continue;
                    }
                    wardrobe[color][curWear]++;
                }
            }
            string[] choosenWearArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string choosenColor = choosenWearArr[0];
            string choosenWear = choosenWearArr[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var wear in color.Value)
                {
                    if (color.Key == choosenColor && wear.Key == choosenWear)
                    {
                        Console.WriteLine($"* {wear.Key} - {wear.Value} (found!)");
                        continue;
                    }
                    Console.WriteLine($"* {wear.Key} - {wear.Value}");
                }
            }
        }
    }
}
