using System;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInput = Console.ReadLine().Split();
                string[] curDough = Console.ReadLine().Split();
                Dough dough = new Dough(curDough[1], curDough[2], int.Parse(curDough[3]));
                Pizza pizza = new Pizza(pizzaInput[1], dough);

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] curTopping = command.Split();

                    Topping topping = new Topping(curTopping[1], int.Parse(curTopping[2]));
                    pizza.Add(topping);
                    double check = topping.Calories;
                }
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
