

namespace Raiding.Models
{
    abstract class BaseHero : IBaseHero
    {        
        public BaseHero(string name)
        {
            this.Name = name;
        }
        public string Name { get; private set; }

        public abstract int Power { get; }

        public abstract string CastAbility();
        
    }
}
