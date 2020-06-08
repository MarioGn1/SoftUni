using System;
using System.Collections.Generic;
using System.IO;

namespace Merge_files
{
    class Program
    {
        static void Main(string[] args)
        {
            var path1 = Path.Combine("data", "input1.txt");
            var path2 = Path.Combine("data", "input2.txt");
            var destPath = Path.Combine("data", "output.txt");

            SortedSet<string> set = new SortedSet<string>();

            string[] linesInput1 = File.ReadAllLines(path1);
            string[] linesInput2 = File.ReadAllLines(path2);

            foreach (var item in linesInput1)
            {
                set.Add(item);
            }
            foreach (var item in linesInput2)
            {
                set.Add(item);
            }

            File.WriteAllLines(destPath, set);

            GC.Collect();
        }
    }
}
