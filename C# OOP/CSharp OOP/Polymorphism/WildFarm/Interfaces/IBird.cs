
using WildFarm.Models.Animals;

namespace WildFarm.Interfaces
{
    public interface IBird : IAnimal
    {
        double WingSize { get; }
    }
}
