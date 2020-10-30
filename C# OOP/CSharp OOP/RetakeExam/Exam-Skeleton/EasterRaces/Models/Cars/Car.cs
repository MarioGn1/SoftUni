using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            Model = model;
            MinHorsePower = minHorsePower;
            MaxHorsePower = maxHorsePower;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
            
        }

        public string Model
        {
            get
            {
                return model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, 4));
                }
                this.model = value;
            }
        }

        public virtual int HorsePower 
        {
            get => this.horsePower;
            private set
            {
                if (value < MinHorsePower || value > MaxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                this.horsePower = value;
            }
        }
        public double CubicCentimeters { get; private set; }
        public int MinHorsePower { get; private set; }
        public int MaxHorsePower { get; private set; }


        public double CalculateRacePoints(int laps)
        {
            return (this.CubicCentimeters / HorsePower) * laps * 1.00;
        }
    }
}
