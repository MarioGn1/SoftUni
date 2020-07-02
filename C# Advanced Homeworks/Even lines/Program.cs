using System;
using System.IO;
using System.Linq;

namespace Even_lines
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine("data", "input.txt");

            

            using (FileStream inputStream = new FileStream(path, FileMode.Open) )
            {
                using (TextReader inputText = new StreamReader(inputStream))
                {
                    int counter = 0;
                    string text;
                    char [] separators = new char [] { '-', ',', '.', '!', '?' };
                    while ((text = inputText.ReadLine()) != null)
                    {
                        if (counter % 2 == 0)
                        {
                            string[] curLine = text.Split();
                            Array.Reverse(curLine);

                            text = string.Join(' ', curLine);
                            string[] reversedCurLine = text.Split(separators,StringSplitOptions.RemoveEmptyEntries);

                            Console.WriteLine(string.Join('@', reversedCurLine));                                                           
                        }
                        counter++;
                    }
                }
            }
        }
    }
}
