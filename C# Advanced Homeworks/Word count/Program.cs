using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Word_count
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordPath = Path.Combine("data", "word.txt");
            var inputPath = Path.Combine("data", "input.txt");
            var destPath = Path.Combine("data", "output.txt");

            Dictionary<string, int> wordsContainsList = new Dictionary<string, int>();

            using (FileStream wordsFile = new FileStream(wordPath, FileMode.Open))
            {
                using (TextReader wordText = new StreamReader(wordsFile))
                {
                    string line;
                    while ((line = wordText.ReadLine()) != null)
                    {
                        // Regex patern = new Regex(@"[A-Za-z]+");

                        string[] words = line.Split(new char[] {',','.','?','!',' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var item in words)
                        {
                            string curWord = item.ToLower();
                            if (!wordsContainsList.ContainsKey(curWord))
                            {
                                wordsContainsList[curWord] = 0;
                            }
                        }
                    }
                    
                }
            }

            using (FileStream inputFile = new FileStream(inputPath, FileMode.Open))
            {
                using (TextReader inputText = new StreamReader(inputFile))
                {
                    string line;
                    while ((line = inputText.ReadLine()) != null)
                    {
                        // Regex patern = new Regex(@"[A-Za-z]+");
                        string[] words = line.Split(new char[] { ',', '.', '?', '!', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var item in words)
                        {
                            string curWord = item.ToLower();
                            if (wordsContainsList.ContainsKey(curWord))
                            {
                                wordsContainsList[curWord]++;
                            }
                        }
                    }
                 }
            }

            var sortedWords = wordsContainsList.OrderByDescending(v => v.Value);

            using (FileStream outputFile = new FileStream(destPath, FileMode.OpenOrCreate))
            {
                using (TextWriter outputText = new StreamWriter(outputFile))
                {
                    foreach (var item in sortedWords)
                    {
                        outputText.WriteLine($"{item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
