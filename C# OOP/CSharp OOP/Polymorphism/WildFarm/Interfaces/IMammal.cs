

using WildFarm.Models.Animals;

namespace WildFarm.Interfaces
{
    public interface IMammal : IAnimal
    {
        string LivingRegion { get; }
    }
}
