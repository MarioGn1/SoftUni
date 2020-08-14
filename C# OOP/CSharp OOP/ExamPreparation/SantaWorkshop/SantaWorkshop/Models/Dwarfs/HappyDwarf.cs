using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public class HappyDwarf : Dwarf
    {
        private const int Initial_Energy = 100;

        public HappyDwarf(string name) : base(name, Initial_Energy)
        {
        }
    }
}
