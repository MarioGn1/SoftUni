﻿
using WildFarm.Interfaces;

namespace WildFarm.Models.Animals
{
    public abstract class Mammal : Animal, IMammal
    {
        protected Mammal(string name, double weight, string livingRegion) 
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
