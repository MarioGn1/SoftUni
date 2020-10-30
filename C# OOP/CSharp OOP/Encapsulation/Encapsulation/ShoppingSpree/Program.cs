using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separators = new char[] { ';', '=' };
            string[] personsInput = Console.ReadLine().Split(separators);
            string[] productsInput = Console.ReadLine().Split(separators,StringSplitOptions.RemoveEmptyEntries);

            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                for (int i = 0; i < personsInput.Length; i = i + 2)
                {
                    Person curPerson = new Person(personsInput[i], decimal.Parse(personsInput[i + 1]));
                    persons.Add(curPerson);
                }

                for (int i = 0; i < productsInput.Length; i = i + 2)
                {
                    Product curPerson = new Product(productsInput[i], decimal.Parse(productsInput[i + 1]));
                    products.Add(curPerson);
                }

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] curCommand = command.Split();
                Person curPerson = persons.First(el => el.Name == curCommand[0]);
                int personIndex = persons.IndexOf(curPerson);
                Product curProduct = products.First(el => el.Name == curCommand[1]);

                Console.WriteLine(persons[personIndex].Add(curProduct));
            }

            foreach (Person person in persons)
            {
                if (person.Bag.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Bag)}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought ");
                }                
            }
        }
    }
}
