using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interfaces;

namespace WildFarm.Models.Food
{
    public abstract class Food : IFood
    {
        protected Food(int qty)
        {
            this.Qty = qty;
        }
        public int Qty { get; private set; }
    }
}
