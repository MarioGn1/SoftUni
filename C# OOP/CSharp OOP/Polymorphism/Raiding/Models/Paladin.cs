

namespace Raiding.Models
{
    class Paladin : BaseHero
    {
        private const int PALADIN_POWER = 100;

        public Paladin(string name) : base(name)
        {
        }

        public override int Power => PALADIN_POWER;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
