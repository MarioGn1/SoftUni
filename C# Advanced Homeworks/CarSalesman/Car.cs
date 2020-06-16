using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    class Car
    {        
        public string Weight { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

        public Engine Engine { get; set; }

        public Car()
        {
            this.Model = "n/a";
            this.Engine = null;
            this.Weight = "n/a";
            this.Color = "n/a";
        }
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = "n/a";
            this.Color = "n/a";
        }

        public Car(string model, Engine engine, double weight) : this(model, engine)
        {
            this.Weight = weight.ToString();
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, double weight, string color) : this(model, engine, color)
        {
            this.Weight = weight.ToString();
        }
    }
}
