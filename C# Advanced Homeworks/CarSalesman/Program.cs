using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] engineDetails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Engine curEngine = new Engine();

                string model = engineDetails[0];
                string power = engineDetails[1];

                if (engineDetails.Length == 3 && Char.IsDigit(engineDetails[2][0]))
                {
                    curEngine = new Engine(model, power, double.Parse(engineDetails[2]));                    
                }
                else if (engineDetails.Length == 3 && Char.IsLetter(engineDetails[2][0]))
                {
                    curEngine = new Engine(model, power, engineDetails[2]);                   
                }
                else if (engineDetails.Length == 4)
                {
                    curEngine = new Engine(model, power, double.Parse(engineDetails[2]), engineDetails[3]);                    
                }
                else
                {
                    curEngine = new Engine(model, power);                    
                }
                engines.Add(curEngine);
            }

            int m = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                string[] carDetails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string curCarModel = carDetails[0]; // car 1
                string curEngineModel = carDetails[1];

                Engine curCarEngine = new Engine();      // engine 2          

                foreach (Engine item in engines)
                {
                    if (item.Model == curEngineModel)
                    {
                        curCarEngine = item;
                        break;
                    }
                }

                _ = new Car();
                Car curCar;
                if (carDetails.Length == 3 && Char.IsDigit(carDetails[2][0]))
                {
                    curCar = new Car(curCarModel, curCarEngine, double.Parse(carDetails[2]));                    
                }
                else if (carDetails.Length == 3 && Char.IsLetter(carDetails[2][0]))
                {
                    curCar = new Car(curCarModel, curCarEngine, carDetails[2]);                    
                }
                else if (carDetails.Length == 4)
                {
                    curCar = new Car(curCarModel, curCarEngine, double.Parse(carDetails[2]), carDetails[3]);                    
                }
                else
                {
                    curCar = new Car(curCarModel, curCarEngine);                    
                }
                cars.Add(curCar);
            }

            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Model}:");
                Console.WriteLine($"  {item.Engine.Model}:");
                Console.WriteLine($"    Power: {item.Engine.Power}");
                Console.WriteLine($"    Displacement: {item.Engine.Displacement}");
                Console.WriteLine($"    Efficiency: {item.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {item.Weight}");
                Console.WriteLine($"  Color: {item.Color}");                
            }
        }
    }
}
