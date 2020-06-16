using System;
using System.Collections.Generic;
using System.Dynamic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PersonsAboveAge party = new PersonsAboveAge();

            for (int i = 0; i < n; i++)
            {
                string[] curPerson = Console.ReadLine().Split();
                Person person = new Person(curPerson[0], int.Parse(curPerson[1]));
                party.AddPerson(person);
            }

            List<Person> sortedParty = party.SortByAge();
            foreach (var item in sortedParty)
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
            
        }
    }
}
