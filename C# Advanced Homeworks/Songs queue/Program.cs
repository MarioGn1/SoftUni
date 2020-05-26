using System;
using System.Collections.Generic;

namespace Songs_queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songsArr = Console.ReadLine().Split(", ");

            Queue<string> playList = new Queue<string>(songsArr);

            
            while (playList.Count > 0)
            {
                string command = Console.ReadLine();


                if (command == "Play")
                {
                    if (playList.Count > 0)
                    {
                        playList.Dequeue();
                    }

                }
                else if (command.Contains("Add"))
                {
                    string song = command.Remove(0, 4);
                    if (!playList.Contains(song))
                    {
                        playList.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (command == "Show")
                {
                    if (playList.Count > 0)
                    {
                        Console.WriteLine(string.Join(", ", playList));
                    }
                }
            }
                              
                Console.WriteLine("No more songs!");
                
            
        }
    }
}
