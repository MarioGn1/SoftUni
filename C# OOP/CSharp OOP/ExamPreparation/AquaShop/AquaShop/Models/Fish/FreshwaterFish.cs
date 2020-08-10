﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

namespace AquaShop.Models.Fish
{
    class FreshwaterFish : Fish
    {
        
        public FreshwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
            this.Size = 3;
        }

        public override void Eat()
        {
            this.Size += 3;
        }
    }
}
