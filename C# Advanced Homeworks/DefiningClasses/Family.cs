using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    class Family
    {
        private List<Person> members;

        public List<Person> Members
        {
            get { return members; }
            set { members = value; }
        }

        public Family()
        {
            this.Members = new List<Person>();
        }

        public void AddMember(Person member)
        {
            Members.Add(member);

        }

        public Person GetOldestMember()
        {
            Person person = this.Members.OrderByDescending(p => p.Age).FirstOrDefault();
            return person;
        }

    }
}
