using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ComparingObjects
{
    class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        //public string Town { get; set; }

        public Person(string name, int age)// string town)
        {
            this.Name = name;
            this.Age = age;
            //this.Town = town;
        }

        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name)!=0)
            {
                return this.Name.CompareTo(other.Name);
            }
            else if (this.Age.CompareTo(other.Age)!=0)
            {
                return this.Age.CompareTo(other.Age);
            }
            //else if (this.Town.CompareTo(other.Town) != 0)
            //{
            //    return this.Town.CompareTo(other.Town);
            //}
            else
            {
                return 0;
            }
            
        }
        public override bool Equals(object obj)
        {
            if (this.GetHashCode() == obj.GetHashCode())
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }
    }
}
