using System;
using System.Collections.Generic;
using System.Linq;

namespace Predicate_party
{
    class Program
    {
        public delegate List<string> Actions(List<string> x, string z);
        static void Main(string[] args)
        {
            Actions removeStartsWith = (x, y) => x.RemoveAll(n => n.StartsWith(y)).ToString().Split().ToList(); // .Where(el => !(el.StartsWith(y))).ToList();
            Actions removeEndsWith = (x, y) => x.RemoveAll(n => n.EndsWith(y)).ToString().Split().ToList(); //.Where(el => !el.EndsWith(y)).ToList();
            Actions removeSpecificLenght = (x, y) => x.RemoveAll(n => n.Length == int.Parse(y)).ToString().Split().ToList(); //.Where(el => el.Length != int.Parse(y)).ToList();
            Actions doubleStartsWith = (x, y) =>
            {
                for (int i = 0; i < x.Count; i++)
                {
                    if (x[i].StartsWith(y))
                    {
                        x.Insert(i, x[i]);
                        i++;
                    }
                }
                return x;
            };
            Actions doubleEndsWith = (x, y) =>
            {
                for (int i = 0; i < x.Count; i++)
                {
                    if (x[i].EndsWith(y))
                    {
                        x.Insert(i, x[i]);
                        i++;
                    }
                }
                return x;
            };
            Actions doubleSpecificLenght = (x, y) =>
            {
                for (int i = 0; i < x.Count; i++)
                {
                    if (x[i].Length == int.Parse(y))
                    {
                        x.Insert(i, x[i]);
                        i++;
                    }
                }
                return x;
            };

            List<string> guests = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] curCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = curCommand[0];
                string selector = curCommand[1];
                string operationParameter = curCommand[2];
                if (action == "Remove")
                {
                    switch (selector)
                    {
                        case "StartsWith":
                            removeStartsWith(guests, operationParameter);
                            break;
                        case "EndsWith":
                            removeEndsWith(guests, operationParameter);
                            break;
                        case "Length":
                            removeSpecificLenght(guests, operationParameter);
                            break;
                    }
                }
                else if (action == "Double")
                {
                    switch (selector)
                    {
                        case "StartsWith":
                            doubleStartsWith(guests, operationParameter);
                            break;
                        case "EndsWith":
                            doubleEndsWith(guests, operationParameter);
                            break;
                        case "Length":
                            
                            doubleSpecificLenght(guests, operationParameter);
                            break;
                    }
                }
            }

            if (guests.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
