using System;
using System.Threading.Tasks;

namespace Chronometer
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            Chronometer chronometer = new Chronometer();
            while ((command = Console.ReadLine()).ToLower() != "exit")
            {
                switch (command.ToLower())
                {
                    case "stop":
                        chronometer.Stop();
                        break;
                    case "start":
                        chronometer.Start();
                        break;
                    case "reset":
                        chronometer.Reset();
                        break;
                    case "lap":
                        Console.WriteLine(chronometer.Lap());
                        break;
                    case "laps":
                        var laps = chronometer.Laps;
                        if (laps.Count == 0)
                        {
                            Console.WriteLine("Laps: no laps");
                            break;
                        }
                        Console.WriteLine("Laps:");
                        for (int i = 0; i < laps.Count; i++)
                        {
                            Console.WriteLine($"{i}. {laps[i]}");
                        }
                        break;
                    case "time":
                        Console.WriteLine(chronometer.GetTime);
                        break;
                }
            }
        }
    }
}
