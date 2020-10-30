using MilitaryElite.Enumerators;
using MilitaryElite.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = TryParseCorps(corps);
        }

        private Corps TryParseCorps(string corpsStr)
        {
            Corps corps;
            bool parsed = Enum.TryParse(corpsStr, out corps);
            if (!parsed)
            {
                throw new MyExeption();
            }
            return corps;
        }

        public Corps Corps { get; private set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
