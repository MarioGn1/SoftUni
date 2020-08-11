using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private readonly List<IDecoration> decorations;
        private readonly List<IFish> fishes;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.decorations = new List<IDecoration>();
            this.fishes = new List<IFish>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }

        }

        public int Capacity { get;  }

        public int Comfort => this.decorations.Sum(el => el.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations.AsReadOnly();

        public ICollection<IFish> Fish => this.fishes.AsReadOnly();

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.fishes.Count >= this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            
                this.fishes.Add(fish);
                                                
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
            sb.AppendLine($"Fish: {(this.Fish.Any() ? string.Join(", ", this.Fish.Select(x => x.Name)) : "none")}");
            sb.AppendLine($"Decorations: { Decorations.Count}");
            sb.AppendLine($"Comfort: { this.Comfort}");

            return sb.ToString().Trim();
        }

        public bool RemoveFish(IFish fish)
        {

            return this.fishes.Remove(fish);
        }

    }
}
