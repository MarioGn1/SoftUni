using System;
using WildFarm.Enumerators;
using WildFarm.Interfaces;

namespace WildFarm.Models.Animals
{
    class Owl : Bird
    {
        private const double INCRESE_WEIGHT_FACTOR = 0.25;


        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Feed(IFood food)
        {
            this.FoodType = TryParseFoodType(food.GetType().Name);

            if (this.FoodType == FoodType.Meat)
            {
                this.FoodEaten = food.Qty;
                this.Weight += FoodEaten * INCRESE_WEIGHT_FACTOR;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
