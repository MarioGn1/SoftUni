using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;


        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        public string Add(Product product)
        {
            if (this.money >= product.Cost)
            {
                bag.Add(product);
                money -= product.Cost;
                return $"{this.name} bought {product.Name}";
            }
            else
            {
                return $"{this.name} can't afford {product.Name}";
            }
        }

        public List<Product> Bag => bag;

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }        

        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                } 
                money = value; 
            }
        }        
    }
}
