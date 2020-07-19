using System;
using WildFarm.Models.Animals;

namespace WildFarm.Factories
{
    public class AnimalCreator : IAnimalCreator
    {
        public IAnimal CreateAnimal(string[] animalDetails)
        {
            string type = animalDetails[0];
            string name = animalDetails[1];
            double weight = double.Parse(animalDetails[2]);

            IAnimal animal;
            switch (type)
            {
                case "Cat":
                    string catLivingRegion = animalDetails[3];
                    string catbreed = animalDetails[4];
                    animal = new Cat(name, weight, catLivingRegion, catbreed);
                    break;
                case "Tiger":
                    string tigerLivingRegion = animalDetails[3];
                    string tigerBreed = animalDetails[4];
                    animal = new Tiger(name, weight, tigerLivingRegion, tigerBreed);
                    break;
                case "Owl":
                    double owlWingSize = double.Parse(animalDetails[3]);
                    animal = new Owl(name, weight, owlWingSize);
                    break;
                case "Hen":
                    double henWingSize = double.Parse(animalDetails[3]);
                    animal = new Hen(name, weight, henWingSize);
                    break;
                case "Mouse":
                    string mouseLivingRegion = animalDetails[3];
                    animal = new Mouse(name, weight, mouseLivingRegion);
                    break;
                case "Dog":
                    string DogLivingRegion = animalDetails[3];
                    animal = new Dog(name, weight, DogLivingRegion);
                    break;
                default:
                    throw new ArgumentException("Invalid animal input!");
            }

            return animal;
        }
    }
}
