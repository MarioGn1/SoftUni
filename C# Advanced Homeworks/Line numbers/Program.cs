using System;
using System.IO;

namespace Line_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine("data", "input.txt");
            var destPath = Path.Combine("data", "output.txt");

            using (FileStream inputFile = new FileStream(path, FileMode.Open))
            {
                using (TextReader inputText = new StreamReader(inputFile))
                {
                    using (FileStream outputFile = new FileStream(destPath, FileMode.OpenOrCreate))
                    {
                        using (TextWriter outputTex = new StreamWriter(outputFile))
                        {
                            string line;
                            int counter = 1;
                            while ((line = inputText.ReadLine()) != null)
                            {
                                outputTex.WriteLine($"{counter}. {line}");
                                counter++;
                            }

                        }
                    }
                }
            }
        }
    }
}
