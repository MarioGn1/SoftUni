using WildFarm.Interfaces;

namespace WildFarm.Models.Animals
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }

        string ProduceSound();
        void Feed(IFood food);

    }
}
