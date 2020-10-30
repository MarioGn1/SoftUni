using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factories
{
    public interface IHeroCreator
    {
        IBaseHero CreateHero(string name, string type);
    }
}
