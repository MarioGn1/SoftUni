using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;

namespace PizzaCalories
{
    class Dough
    {
        private const double BASE_CALORIES = 2.0;

        private const double WHITE_CALORIES = 1.5;
        private const double WHOLEGRAIN_CALORIES = 1.0;

        private const double CRISPY_CALORIES = 0.9;
        private const double CHEWY_CALORIES = 1.1;
        private const double HOMEMADE_CALORIES = 1.0;

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        private double CalculateCalories()
        {
            double totalCalories = 0.0;
            double baseTotalCalories = BASE_CALORIES * weight;
            switch (this.flourType.ToLower())
            {
                case "white":
                    totalCalories = baseTotalCalories * WHITE_CALORIES;
                    break;
                case "wholegrain":
                    totalCalories = baseTotalCalories * WHOLEGRAIN_CALORIES;
                    break;
            }
            switch (this.bakingTechnique.ToLower())
            {
                case "chewy":
                    totalCalories *= CHEWY_CALORIES;
                    break;
                case "crispy":
                    totalCalories *= CRISPY_CALORIES;
                    break;
                case "homemade":
                    totalCalories *= HOMEMADE_CALORIES;
                    break;
            }
            return totalCalories;
        }

        private string FlourType
        {
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }

        private string BakingTechnique
        {
            set
            {
                if (value.ToLower() != "chewy" && value.ToLower() != "crispy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }

        private int Weight
        {
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        public double Calories => CalculateCalories();
    }
}
