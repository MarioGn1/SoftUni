using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    class Tire
    {
        
        public int Age { get; set; }
        public double Preassure { get; set; }
        public Tire(int age, double preassure)
        {
            this.Age = age;
            this.Preassure = preassure;
        }
        
    }
}
