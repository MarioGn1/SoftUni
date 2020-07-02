using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] curCarArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                List<Tire> tiresCollection = new List<Tire>();

                string model = curCarArr[0];
                int engineSpeed = int.Parse(curCarArr[1]);
                int enginePower = int.Parse(curCarArr[2]);

                int cargoWeight = int.Parse(curCarArr[3]);
                string cargoType = curCarArr[4];
                for (int j = 0; j < 8; j++)
                {
                    double curPreasure = double.Parse(curCarArr[j + 5]);
                    int curAge = int.Parse(curCarArr[j + 6]);
                    Tire curTire = new Tire(curAge, curPreasure);
                    tiresCollection.Add(curTire);
                    j++;
                }


                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Car curCar = new Car(model, engine, cargo, tiresCollection);
                cars.Add(curCar);
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                cars
                    .Where(x => x.Cargo.Type == command)
                    .Where(x => x.Tires.Any(t => t.Preassure < 1))
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model)); 
            }
            else if (command == "flamable")
            {
                cars
                    .Where(el => el.Cargo.Type == "flamable")
                    .Where(el => el.Engine.Power > 250)
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));
            }


        }
    }
}
