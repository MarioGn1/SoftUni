using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public Car()
        {

        }
        public Car(string Model)
        {
            this.Model = Model;
        }
        public Car(double TravelledDistance)
        {
            this.TravelledDistance += TravelledDistance;
        }
        public Car(string Model, double FuelAmount, double FuelConsumptionPerKilometer)
        {
            this.Model = Model;
            this.FuelAmount = FuelAmount;
            this.FuelConsumptionPerKilometer = FuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }

        public Car Travel(Car car, double distance)
        {          
            if (distance * car.FuelConsumptionPerKilometer <= car.FuelAmount)
            {
                car.FuelAmount -= distance * car.FuelConsumptionPerKilometer;
                car.TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }          
            return car;
        }
    }
}
