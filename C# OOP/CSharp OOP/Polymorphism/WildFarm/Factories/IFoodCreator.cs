

using WildFarm.Interfaces;

namespace WildFarm.Factories
{
    public interface IFoodCreator
    {
        IFood CreateFood(string[] foodDetails);
    }
}
