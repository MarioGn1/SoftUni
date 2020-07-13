using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    class Topping
    {
        private const double BASE_CALORIES = 2;

        private const double MEAT_CALORIES = 1.2;
        private const double VEGGIES_CALORIES = 0.8;
        private const double CHEESE_CALORIES = 1.1;
        private const double SAUCE_CALORIES = 0.9;

        private string type;
        private int weight;

        public Topping(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }        

        private double CalculateCalories()
        {
            double totalCalories = 0.0;
            double baseTotalCalories = BASE_CALORIES * weight;
           
            switch (this.type.ToLower())
            {
                case "meat":
                    totalCalories = baseTotalCalories * MEAT_CALORIES;
                    break;
                case "veggies":
                    totalCalories = baseTotalCalories * VEGGIES_CALORIES;
                    break;
                case "cheese":
                    totalCalories = baseTotalCalories * CHEESE_CALORIES;
                    break;
                case "sauce":
                    totalCalories = baseTotalCalories * SAUCE_CALORIES;
                    break;
            }
            return totalCalories;
        }

        private int Weight 
        {
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }

        private string Type
        {
            set
            {
                if (value.ToLower() != "meat" && 
                    value.ToLower() != "veggies" &&
                    value.ToLower() != "cheese" && 
                    value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }

        public double Calories => CalculateCalories();
    }
}
