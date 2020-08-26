using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double Const_CubicCentimeters = 5000.00;
        private const int Const_MinHorsePower = 400;
        private const int Comst_MaxHorsePower = 600;

        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, Const_CubicCentimeters, Const_MinHorsePower, Comst_MaxHorsePower)
        {
        }
    }
}
