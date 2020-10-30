

using WildFarm.Models.Animals;

namespace WildFarm.Factories
{
    public interface IAnimalCreator
    {
        IAnimal CreateAnimal(string[] animalDetails);
    }
}
