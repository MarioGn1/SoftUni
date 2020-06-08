using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Line_numbers__exercise_
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine("data", "input.txt");
            var dest = Path.Combine("data", "output.txt");

            string[] lines = File.ReadAllLines(path);
            string[] formatedLines = new string[lines.Length];
            Regex paternPunctoation = new Regex(@"[-,.?;:'!]");
            Regex paternLeters = new Regex(@"[A-Za-z]");
            
            for (int i = 0; i < lines.Length ; i++)
            {
                MatchCollection matchedPunctoations = paternPunctoation.Matches(lines[i]);
                MatchCollection matchedLeters = paternLeters.Matches(lines[i]);

                formatedLines[i] = $"Line {i+1}: {lines[i]} ({matchedLeters.Count})({matchedPunctoations.Count})";                
            }

            File.WriteAllLines(dest, formatedLines);
        }
    }
}
