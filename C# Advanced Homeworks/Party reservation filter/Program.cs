using System;
using System.Collections.Generic;
using System.Linq;

namespace Party_reservation_filter
{
    class Program
    {
        public delegate List<string> Actions(List<string> x, string z);

        static void Main(string[] args)
        {
            Actions removeNameStartsWith = (targetList, criteria) => targetList.RemoveAll(n => n.StartsWith(criteria)).ToString().Split().ToList();
            Actions removeNameEndsWith = (targetList, criteria) => targetList.RemoveAll(n => n.EndsWith(criteria)).ToString().Split().ToList();
            Actions removeNameSpecificLenght = (targetList, criteria) => targetList.RemoveAll(n => n.Length == int.Parse(criteria)).ToString().Split().ToList();
            Actions removeNameWithSubContains = (targetList, criteria) => targetList.RemoveAll(n => n.Contains(criteria)).ToString().Split().ToList();

            Action<List<string>> print = finalList => Console.WriteLine(string.Join(' ', finalList));

            List<string> guests = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            Dictionary<string, List<string>> appliedFilters = new Dictionary<string, List<string>>();

            string command;
            while ((command = Console.ReadLine()) != "Print")
            {
                string[] curCommand = command.Split(';');
                string action = curCommand[0];
                string filter = curCommand[1];
                string parameter = curCommand[2];

                switch (action)
                {
                    case "Add filter":
                        if (!appliedFilters.ContainsKey(filter))
                        {
                            appliedFilters[filter] = new List<string>();
                        }
                        appliedFilters[filter].Add(parameter);
                        break;
                    case "Remove filter":
                        appliedFilters[filter].Remove(parameter);
                        break;
                    default:
                        throw new ArgumentException("Invalid operation!");
                }
            }
            foreach (var filter in appliedFilters)
            {
                foreach (var parameter in filter.Value)
                {
                    switch (filter.Key)
                    {
                        case "Starts with":
                            removeNameStartsWith(guests, parameter);
                            break;
                        case "Ends with":
                            removeNameEndsWith(guests, parameter);
                            break;
                        case "Length":
                            removeNameSpecificLenght(guests, parameter);
                            break;
                        case "Contains":
                            removeNameWithSubContains(guests, parameter);
                            break;
                    }
                }
            }
            print(guests);
        }
    }
}
