using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public class FreshwaterAquarium : Aquarium
    {
        private const int defaultCapacity = 50;
        public FreshwaterAquarium(string name) : base(name, defaultCapacity)
        {
        }
    }
}
