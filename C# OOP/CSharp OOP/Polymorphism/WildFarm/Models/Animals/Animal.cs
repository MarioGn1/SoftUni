using System;
using WildFarm.Enumerators;
using WildFarm.Interfaces;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public virtual string ProduceSound()
        { return string.Empty; }

        public virtual void Feed(IFood food) { }

        protected FoodType TryParseFoodType(string name)
        {
            FoodType foodType;
            bool parse = Enum.TryParse(name, out foodType);
            if (!parse)
            {
                throw new ArgumentException("Invalid enum food input!");
            }
            return foodType;
        }


        public string Name { get; private set; }
        public double Weight { get; set; }

        public int FoodEaten { get;  set; }

        protected FoodType FoodType { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}";
        }

        
    }
}
