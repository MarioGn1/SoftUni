using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{ 
    public class SleepyDwarf :Dwarf
    {
        private const int Initial_Energy = 50;

        public SleepyDwarf(string name) : base(name, Initial_Energy)
        {
        }

        public override void Work()
        {
           base.Energy -= 15;
        }
    }
}
