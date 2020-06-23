using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();

            SortedSet<Person> personSortedSet = new SortedSet<Person>();
            HashSet<Person> personHashSet = new HashSet<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] curCommand = Console.ReadLine().Split();
                string name = curCommand[0];
                int age = int.Parse(curCommand[1]);
                Person curPerson = new Person(name, age);
                if (!personHashSet.Contains(curPerson))
                {
                    personHashSet.Add(curPerson);
                }                
                personSortedSet.Add(curPerson);
            }
            //string command;
            //while ((command = Console.ReadLine()) != "END")
            //{
            //    string[] curCommand = command.Split();
            //    string name = curCommand[0];
            //    int age = int.Parse(curCommand[1]);
            //    string town = curCommand[2];
                
            //    Person curPerson = new Person(name, age, town);
            //    persons.Add(curPerson);
                
            //}

            //int n = int.Parse(Console.ReadLine());

            //Person target = persons[n - 1];
            //int countEquals = 0;
            //int countNotEquals = 0;

            //foreach (var item in persons)
            //{
            //    int res = target.CompareTo(item);

            //    if (res != 0)
            //    {
            //        countNotEquals++; 
            //    }
            //    else
            //    {
            //        countEquals++;
            //    }
            //}
            //if (countEquals == 1)
            //{
            //    Console.WriteLine("No matches");
            //}
            //else
            //{
            //    Console.WriteLine($"{countEquals} {countNotEquals} {persons.Count}");
            //}

            Console.WriteLine(personHashSet.Count);
            Console.WriteLine(personSortedSet.Count);
        }
    }
}
