using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Directory_traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string sortPatern = ".";
            var path = Path.Combine("C:", "Users", "User", "Downloads");
            var dest = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "report.txt");
            string[] files = Directory.GetFiles(path, $"*{sortPatern}*");

            Dictionary<string, Dictionary<string, double>> filesInfo = new Dictionary<string, Dictionary<string, double>>();

            foreach (var item in files)
            {
                FileInfo file = new FileInfo(item);

                string fileName = file.Name;                
                string fileType = file.Extension;

                if (!filesInfo.ContainsKey(fileType))
                {
                    filesInfo[fileType] = new Dictionary<string, double>();
                }
                filesInfo[fileType][fileName] = file.Length / 1024.0;
            }

            var sortedFilesInfo = filesInfo
                .OrderByDescending(k => k.Value.Count)
                .ThenBy(k => k.Key)
                .ThenBy(v => v.Value.Values.Sum())
                .ToDictionary(k => k.Key, v => v.Value.OrderBy(x => x.Value));

            foreach (var fileType in sortedFilesInfo)
            {
                File.AppendAllText(dest, $"{fileType.Key}\n");
                foreach (var file in fileType.Value)
                {
                    File.AppendAllText(dest, $"--{file.Key} - {file.Value:F3}kb\n");
                }
            }
        }
    }
}
