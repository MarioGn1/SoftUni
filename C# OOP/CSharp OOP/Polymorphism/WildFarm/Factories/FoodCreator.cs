

using System;
using WildFarm.Interfaces;
using WildFarm.Models.Food;

namespace WildFarm.Factories
{
    class FoodCreator : IFoodCreator
    {
        public IFood CreateFood(string[] foodDetails)
        {
            string foodType = foodDetails[0];
            int foodQty = int.Parse(foodDetails[1]);

            IFood food;
            switch (foodType)
            {
                case "Vegetable":
                    food = new Vegetable(foodQty);
                    break;
                case "Fruit":
                    food = new Fruit(foodQty);
                    break;
                case "Meat":
                    food = new Meat(foodQty);
                    break;
                case "Seeds":
                    food = new Seeds(foodQty);
                    break;
                default:
                    throw new ArgumentException("Invalid food input!");
            }
            return food;
        }
    }
}
