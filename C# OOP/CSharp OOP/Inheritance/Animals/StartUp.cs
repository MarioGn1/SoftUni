using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();            
            string command;
            while ((command = Console.ReadLine()) != "Beast!")
            {
                string[] animalDetails = Console.ReadLine().Split(' ');
                string name = animalDetails[0];
                int age = int.Parse(animalDetails[1]);                                               

                try
                {
                    switch (command)
                    {
                        case "Dog":
                            Dog dog = new Dog(name, age, animalDetails[2]);
                            animals.Add(dog);
                            break;
                        case "Cat":
                            Cat cat = new Cat(name, age, animalDetails[2]);
                            animals.Add(cat);
                            break;
                        case "Frog":
                            Frog frog = new Frog(name, age, animalDetails[2]);
                            animals.Add(frog);
                            break;
                        case "Kitten":
                            Kitten kitten = new Kitten(name, age);
                            animals.Add(kitten);
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(name, age);
                            animals.Add(tomcat);
                            break;
                        default:
                            throw new ArgumentException();
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid input!");
                }

            }


            foreach (Animal item in animals)
            {
                Console.WriteLine(item);                
            }

        }
    }
}
