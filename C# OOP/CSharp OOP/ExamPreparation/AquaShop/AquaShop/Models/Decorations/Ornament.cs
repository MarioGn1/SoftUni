using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    internal class Ornament : Decoration
    {
        private const int ORNAMENT_COMFORT = 1;
        private const decimal ORNAMENT_PRICE = 5;

        public Ornament(): base(ORNAMENT_COMFORT, ORNAMENT_PRICE)
        {
        }
    }
}
