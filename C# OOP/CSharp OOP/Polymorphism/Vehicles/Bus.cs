using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double AC_RISE_CONSUMPTION = 1.4;
        public Bus(double fuelQty, double fuelConsumption, double tankCapacity) : base(fuelQty, fuelConsumption + AC_RISE_CONSUMPTION, tankCapacity)
        {
        }

        public string DriveEmpty (double distance)
        {
            this.FuelConsumption -= AC_RISE_CONSUMPTION;

            return this.Drive(distance);
        }
    }
}
