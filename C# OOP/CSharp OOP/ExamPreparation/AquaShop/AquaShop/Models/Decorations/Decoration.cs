using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    internal abstract class Decoration : IDecoration
    {

        protected Decoration(int comfort, decimal price)
        {
            Comfort = comfort;
            Price = price;
        }
        public int Comfort { get; private set; }

        public decimal Price { get; private set; }
    }
}
