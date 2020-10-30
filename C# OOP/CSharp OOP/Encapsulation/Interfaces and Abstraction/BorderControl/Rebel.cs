using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    class Rebel :  IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 0;
        }

        public void BuyFood()
        {
            this.Food += 5;
        }

        public string Group { get; set; }

        public string Id => throw new NotImplementedException();

        public string Name { get; private set; }

        public string Birthday => throw new NotImplementedException();

        public int Age { get; private set; }

        public int Food { get; private set; }


    }
}
