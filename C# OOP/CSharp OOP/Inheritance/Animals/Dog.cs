using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Dog : Animal
    {
        public Dog(string name, int age, string gander) : base(name, age, gander)
        {
        }
        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
