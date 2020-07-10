using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    class Child: Person
    {
        public string Name { get; set; }

        private int age;

        public int Age
        {
            get { return age; }
            set
            {
                if (value <= 15)
                {
                    age = value;
                }
            }
        }

        public Child(string name, int age): base(name,age)
        {

        }

    }
}
