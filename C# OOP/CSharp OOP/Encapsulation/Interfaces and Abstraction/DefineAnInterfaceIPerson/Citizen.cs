using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    class Citizen : IPerson
    {
        public Citizen(string name, int age)
        {
            this.Age = age;
            this.Name = name;
        }
        
        public int Age
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }
    }
}
