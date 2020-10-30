using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Frog : Animal
    {
        public Frog(string name, int age, string gander) : base(name, age, gander)
        {
        }
        public override string ProduceSound()
        {
            return "Ribbit";
        }
      
    }
}
