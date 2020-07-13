using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name,Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        internal void Add(Topping topping)
        {
            if (this.toppings.Count < 10)
            {
                this.toppings.Add(topping);
            }
            else
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
        }

        private double CalculateCalories()
        {
            double sum = 0.0;
            foreach (var item in toppings)
            {
                sum += item.Calories;
            }
            sum += this.dough.Calories;
            return sum;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }        

        public Dough Dough
        {            
             set { dough = value; }
        }

        public int NumberOfToppings => toppings.Count;

        public double TotalCalories => CalculateCalories();
    }
}
