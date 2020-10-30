using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double AC_RISE_CONSUMPTION = 0.9;
        public Car(double fuelQty, double fuelConsumption, double tankCapacity) : base(fuelQty, fuelConsumption + AC_RISE_CONSUMPTION, tankCapacity)
        {
        }
        
        
    }
}
