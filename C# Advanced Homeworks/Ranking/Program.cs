using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            string command;

            while ((command = Console.ReadLine()) != "end of contests")
            {
                string[] curCommand = command.Split(':');
                string curContest = curCommand[0];
                string pass = curCommand[1];
                if (!contests.ContainsKey(curContest))
                {
                    contests[curContest] = pass;
                }
            }
            Dictionary<string, Dictionary<string, int>> ranking = new Dictionary<string, Dictionary<string, int>>();
            while ((command = Console.ReadLine()) != "end of submissions")
            {
                string[] curCommand = command.Split("=>");
                string curContest = curCommand[0];
                string pass = curCommand[1];
                string name = curCommand[2];
                int points = int.Parse(curCommand[3]);

                if (contests.ContainsKey(curContest) && contests[curContest] == pass)
                {
                    if (!ranking.ContainsKey(name))
                    {
                        ranking[name] = new Dictionary<string, int>();
                        ranking[name][curContest] = points;
                    }
                    else
                    {
                        if (!ranking[name].ContainsKey(curContest))
                        {
                            ranking[name][curContest] = points;
                        }
                        else
                        {
                            if (ranking[name][curContest] < points)
                            {
                                ranking[name][curContest] = points;
                            }
                        }
                    }
                }


            }
            string bestCandidate = string.Empty;
            int maxScore = int.MinValue;
            

            foreach (var name in ranking)
            {
                int sum = 0;
                foreach (var contest in name.Value)
                {
                    sum += contest.Value;
                }
                if (maxScore < sum)
                {
                    maxScore = sum;
                    bestCandidate = name.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestCandidate} with total {maxScore} points.");

            var sortedRanking = ranking
                .OrderBy(k => k.Key)
                .ThenByDescending(v => v.Value.Values.Sum())
                .ToDictionary(k => k.Key, v => v.Value.OrderByDescending(x => x.Value));

            Console.WriteLine("Ranking:");
            foreach (var name in sortedRanking)
            {
                Console.WriteLine(name.Key);
                foreach (var item in name.Value)
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
