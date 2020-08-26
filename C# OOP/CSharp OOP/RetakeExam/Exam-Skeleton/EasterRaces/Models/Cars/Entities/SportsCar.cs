using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double Const_CubicCentimeters = 3000.00;
        private const int Const_MinHorsePower = 250;
        private const int Comst_MaxHorsePower = 450;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower, Const_CubicCentimeters, Const_MinHorsePower, Comst_MaxHorsePower)
        {
        }
    }
}
