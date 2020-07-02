using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] curCarArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Car curCar = new Car(curCarArr[0], double.Parse(curCarArr[1]), double.Parse(curCarArr[2]));
                cars.Add(curCar);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string [] curCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string carModel = curCommand[1];
                double distance = double.Parse(curCommand[2]);

                foreach (var item in cars)
                {
                    if (item.Model == carModel)
                    {
                        int index = cars.IndexOf(item);
                        cars[index] =  item.Travel(item, distance);
                        break;
                    }
                }
            }

            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Model} {item.FuelAmount:f2} {item.TravelledDistance}");
            }
        }
    }
}
