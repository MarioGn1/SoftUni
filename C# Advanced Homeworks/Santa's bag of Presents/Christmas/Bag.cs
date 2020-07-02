using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    class Bag
    {
        private List<Present> presents;

        public Bag(string color, int capacity)
        {
            this.Color = color;
            this.Capacity = capacity;
            this.presents = new List<Present>();
        }

        public void Add(Present present)
        {
            if (this.Capacity > presents.Count)
            {
                this.presents.Add(present);
            }            
        }

        public bool Remove(string name)
        {
            bool isRemoved = false;
            if (presents.Any(el => el.Name == name))
            {
                isRemoved = true;
                this.presents = presents.Where(pl => pl.Name != name).ToList();
            }
            return isRemoved;
        }

        public Present GetHeaviestPresent()
        {            
            //double maxWeight = 0.0;           
            //foreach (var item in presents)
            //{
            //    if (item.Weight > maxWeight)
            //    {
            //        maxWeight = item.Weight;                    
            //    }
            //}
            return presents.OrderByDescending(x => x.Weight).FirstOrDefault();
        }

        public Present GetPresent(string name)
        {
            return presents.FirstOrDefault(el => el.Name == name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Color} bag contains:");

            foreach (var item in presents)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }

        public string Color { get; set; }
        public int Capacity { get; set; }
        public int Count => presents.Count;

    }
}
