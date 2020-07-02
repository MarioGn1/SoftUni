using System;
using System.IO;

namespace Folder_size
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine("C:", "Users", "User", "Downloads");
            var dest = Path.Combine("data", "output.txt");
            string[] files = Directory.GetFiles(path);

            double sum = 0;
            foreach (var file in files)
            {
                FileInfo curFile = new FileInfo(file);
                sum += curFile.Length;
            }
            
            File.WriteAllText(dest, $"{sum / 1024 / 1024} MB");
        }
    }
}
