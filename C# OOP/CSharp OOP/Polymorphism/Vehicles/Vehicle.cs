using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQty, double fuelConsumption, double tankCapacity )
        {
            if (fuelQty <= tankCapacity)
            {
                this.FuelQty = fuelQty;
            }
            else
            {
                this.FuelQty = 0.0;
            }
            
            this.FuelConsumption = fuelConsumption;
            if (tankCapacity < 0)
            {
                this.TankCapacity = 0.0;
            }
            else
            {
                this.TankCapacity = tankCapacity;
            }
            
        }

        public string Drive(double distance)
        {
            double requiredFuel = distance * this.FuelConsumption;
            if (requiredFuel <= FuelQty)
            {
                FuelQty -= requiredFuel;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            return $"{this.GetType().Name} needs refueling";
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (this.FuelQty + liters > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            this.FuelQty += liters;
        }


        protected double FuelQty { get; set; }

        protected double FuelConsumption { get; set; }

        public double TankCapacity { get; set; }


        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQty:F2}";
        }

    }
}
