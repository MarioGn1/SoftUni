using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace DefiningClasses
{
    class PersonsAboveAge
    {
        private List<Person> party;        

        public List<Person> Party
        {
            get { return party; }
            set { party = value; }
        }

        public PersonsAboveAge()
        {            
            this.Party = new List<Person>();
        }

        public void AddPerson(Person person)
        {
            Party.Add(person);
        }

        public List<Person> SortByAge()
        {
            var sortedPersons = Party.Where(el => el.Age > 30).OrderBy(el => el.Name).ToList();

            return sortedPersons;
        }
    }

}

