using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Restaurant
{
    class Cake : Dessert
    {
        private const decimal CakePrice = 5;
        public Cake(string name) : base(name, CakePrice, 250, 1000)
        {
        }
    }
}
