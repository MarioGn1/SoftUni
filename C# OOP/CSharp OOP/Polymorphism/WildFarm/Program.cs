using System;
using WildFarm.Core;
using WildFarm.Factories;
using WildFarm.IO;

namespace WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();
            IAnimalCreator animalCreator = new AnimalCreator();
            IFoodCreator foodCreator = new FoodCreator();
            

            IEngine engine = new Engine(reader, writer, animalCreator, foodCreator);
            engine.Run();
        }
    }
}
