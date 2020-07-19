using System;
using System.Collections.Generic;
using WildFarm.Factories;
using WildFarm.Interfaces;
using WildFarm.IO;
using WildFarm.Models.Animals;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly ICollection<IAnimal> animals;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IAnimalCreator animalCreator;
        private readonly IFoodCreator foodCreator;


        public Engine(IReader reader, IWriter writer, IAnimalCreator animalCreator, IFoodCreator foodCreator)
        {
            this.reader = reader;
            this.writer = writer;
            this.animals = new List<IAnimal>();
            this.animalCreator = animalCreator;
            this.foodCreator = foodCreator;
        }

        public void Run()
        {
            int numOfInput = 0;
            IAnimal lastAnimal = null;
            IFood lastFood = null;
            string command;
            while ((command = this.reader.ReadLine()) != "End")
            {
                string[] curInput = command.Split();

                try
                {
                    if (numOfInput % 2 == 0)
                    {
                        IAnimal animal = this.animalCreator.CreateAnimal(curInput);
                        this.animals.Add(animal);
                        lastAnimal = animal;
                    }
                    else
                    {
                        IFood food = this.foodCreator.CreateFood(curInput);
                        lastFood = food;
                    }
                }
                catch (ArgumentException e)
                {
                    this.writer.WriteLine(e.Message);
                }
                
                if (numOfInput % 2 != 0)
                {
                    this.writer.WriteLine(lastAnimal.ProduceSound());
                    try
                    {
                        lastAnimal.Feed(lastFood);
                    }   
                    catch (ArgumentException e)
                    {
                        this.writer.WriteLine(e.Message);
                    }
                }
                numOfInput++;
            }

            foreach (IAnimal animal in animals)
            {
                this.writer.WriteLine(animal.ToString());
            }
        }
    }
}
