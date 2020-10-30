using Microsoft.VisualBasic;
using System;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputCar = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] inputTruck = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] inputBus = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(Console.ReadLine());

            Vehicle car = new Car(double.Parse(inputCar[1]), double.Parse(inputCar[2]), double.Parse(inputCar[3]));
            Vehicle truck = new Truck(double.Parse(inputTruck[1]), double.Parse(inputTruck[2]), double.Parse(inputTruck[3]));
            Vehicle bus = new Bus(double.Parse(inputBus[1]), double.Parse(inputBus[2]), double.Parse(inputBus[3]));

            for (int i = 0; i < n; i++)
            {
                string[] curCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = curCommand[0];
                string vehicleType = curCommand[1];
                double actionParameter = double.Parse(curCommand[2]);

                try
                {
                    switch (action)
                    {
                        case "Drive":
                            DriveCommand(car, truck, bus, vehicleType, actionParameter);
                            break;
                        case "DriveEmpty":
                            Console.WriteLine((bus as Bus).DriveEmpty(actionParameter));
                            break;
                        case "Refuel":
                            RefuelCommand(car, truck, bus, vehicleType, actionParameter);
                            break;
                        default:
                            throw new ArgumentException("Invalid action!");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
               
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void DriveCommand(Vehicle car, Vehicle truck, Vehicle bus, string vehicleType, double actionParameter)
        {
            if (vehicleType == "Car")
            {
                Console.WriteLine((car as Car).Drive(actionParameter));
            }
            else if (vehicleType == "Truck")
            {
                Console.WriteLine((truck as Truck).Drive(actionParameter));
            }
            else if (vehicleType == "Bus")
            {
                Console.WriteLine((bus as Bus).Drive(actionParameter));
            }
        }

        private static void RefuelCommand(Vehicle car, Vehicle truck, Vehicle bus, string vehicleType, double actionParameter)
        {
            if (vehicleType == "Car")
            {
                (car as Car).Refuel(actionParameter);
            }
            else if (vehicleType == "Truck")
            {                
                (truck as Truck).Refuel(actionParameter);
            }
            else if (vehicleType == "Bus")
            {
                (bus as Bus).Refuel(actionParameter);
            }
        }
    }
}
