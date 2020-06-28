using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    class Cage
    {
        private List<Rabbit> rabbits;

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            rabbits = new List<Rabbit>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.rabbits.Count;

        public void Add(Rabbit rabbit)
        {
            if (Capacity > rabbits.Count)
            {
                rabbits.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            Rabbit rabbit = rabbits.FirstOrDefault(el => el.Name == name);
            return rabbits.Remove(rabbit);
        }

        public void RemoveSpecies(string species)
        {
            rabbits = rabbits.Where(el => el.Species != species).ToList();
        }

        public Rabbit SellRabbit(string name)
        {
            Rabbit rabbit = rabbits.FirstOrDefault(el => el.Name == name);
            int index = rabbits.IndexOf(rabbit);
            rabbits[index].Available = false;

            return rabbits[index];
        }

        public Rabbit[]  SellRabbitsBySpecies(string species)
        {
            foreach (var item in rabbits)
            {
                if (item.Species == species)
                {
                    item.Available = false;
                }
            }

            return rabbits.Where(el => el.Species == species).ToArray();
        }

        public string Report()
        {
            var notSoldRabbits = rabbits.Where(el => el.Available);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Rabbits available at {this.Name}:");
            foreach (var item in notSoldRabbits)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
