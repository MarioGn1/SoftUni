using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    internal abstract class Aquarium : IAquarium
    {
        private string name;

        protected Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.Decorations = new List<IDecoration>();
            this.Fish = new List<IFish>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }
                this.name = value;
            }

        }

        public int Capacity { get; private set; }

        public int Comfort => CalculateComfort();        

        public ICollection<IDecoration> Decorations { get; }

        public ICollection<IFish> Fish { get; private set; }


        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count >= this.Capacity)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }
            
                this.Fish.Add(fish);           
            
        }

        public void Feed()
        {
            
            foreach (var item in Fish)
            {
                item.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            if (this.Fish.Count > 0)
            {
                sb.AppendLine($"Fish: {string.Join(", ", Fish.Select(el => el.Name))}");                
            }
            else
            {
                sb.AppendLine("Fish: none");
            }
            sb.AppendLine($"Decorations: { Decorations.Count}");
            sb.AppendLine($"Comfort: { this.Comfort}");

            return sb.ToString().Trim();
        }

        public bool RemoveFish(IFish fish)
        {
            if (this.Fish.Any(el => el.Equals(fish)))
            {
                this.Fish.Remove(fish);
                return true;
            }
            return false;
        }

        private int CalculateComfort()
        {
            int sum = 0;
            foreach (var item in Decorations)
            {
                sum += item.Comfort;
            }
            return sum;
        }
    }
}
