using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factories
{
    class HeroCreator : IHeroCreator
    {
        public IBaseHero CreateHero(string name, string type)
        {
            IBaseHero curHero = null;
            switch (type)
            {
                case "Druid":
                    curHero = new Druid(name);
                    break;
                case "Paladin":
                    curHero = new Paladin(name);
                    break;
                case "Rogue":
                    curHero = new Rogue(name);
                    break;
                case "Warrior":
                    curHero = new Warrior(name);
                    break;
                default:
                    throw new ArgumentException("Invalid hero!");
            }
            return curHero;
        }
    }
}
