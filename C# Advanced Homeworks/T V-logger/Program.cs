using System;
using System.Collections.Generic;
using System.Linq;

namespace T_V_logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> logs = new Dictionary<string, Dictionary<string, List<string>>>();

            string command;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] curCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string firstName = curCommand[0];
                string action = curCommand[1];
                string secondName = curCommand[2];
                switch (action)
                {
                    case "joined":
                        if (!logs.ContainsKey(firstName))
                        {
                            logs[firstName] = new Dictionary<string, List<string>> ();
                            logs[firstName]["followers"] = new List<string>();
                            logs[firstName]["followings"] = new List<string>();
                        }
                        break;
                    case "followed":
                        if (!logs.ContainsKey(firstName) 
                            || !logs.ContainsKey(secondName) 
                            || firstName == secondName
                            || logs[secondName]["followers"].Contains(firstName))
                        {
                            continue;
                        }
                        logs[secondName]["followers"].Add(firstName);
                        logs[firstName]["followings"].Add(secondName);
                        break;
                    default:
                        throw new ArgumentException("Invalid operation!");
                }
            }
            var sortedlogs = logs
                .OrderByDescending(v => v.Value["followers"].Count)
                .ThenBy((v => v.Value["followings"].Count));
                                                      
            Console.WriteLine($"The V-Logger has a total of {logs.Keys.Count} vloggers in its logs.");

            int counter = 1;

            foreach (var item in sortedlogs)
            {
                Console.WriteLine($"{counter}. {item.Key} : {item.Value["followers"].Count} followers, {item.Value["followings"].Count} following");

                if (counter == 1)
                {
                    Console.WriteLine($"*  {string.Join("\n*  ", item.Value["followers"].OrderBy(x => x))}");                 
                }
                counter++;
            }
        }
    }
}
