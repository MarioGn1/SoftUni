using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double AC_RISE_CONSUMPTION = 1.6;
        public Truck(double fuelQty, double fuelConsumption, double tankCapacity) : base(fuelQty, fuelConsumption + AC_RISE_CONSUMPTION, tankCapacity)
        {
        }

        public override void Refuel(double liters)
        {
            
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else if (this.FuelQty + liters > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            liters = liters * 0.95;
            this.FuelQty += liters;
        }
    }
}
