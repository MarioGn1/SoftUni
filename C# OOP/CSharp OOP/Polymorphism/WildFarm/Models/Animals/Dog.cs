using System;
using WildFarm.Enumerators;
using WildFarm.Interfaces;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const double INCRESE_WEIGHT_FACTOR = 0.40;


        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
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
            return "Woof!";
        }
    }
}
