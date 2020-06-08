using System;
using System.IO;

namespace Odd_lines
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine("data", "input.txt");
            var destPath = Path.Combine("data", "output.txt");

            using (FileStream inputfile = new FileStream(path, FileMode.Open))
            {
                using (TextReader text = new StreamReader(inputfile))
                {
                    using (FileStream outputfile = new FileStream(destPath, FileMode.OpenOrCreate))
                    {
                        using (TextWriter outputText = new StreamWriter(outputfile))
                        {
                            string line;
                            int counter = 0;
                            while((line = text.ReadLine()) != null)
                            {
                                if (counter % 2 != 0)
                                {
                                    outputText.WriteLine(line);
                                }
                                counter++;
                            }
                        }
                    }
                }
            }
        }
    }
}
