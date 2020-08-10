using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    class Controller : IController
    {
        private IRepository<Decoration> shopDecorations;
        private ICollection<IAquarium> shopAquariums;

        public Controller()
        {
            shopDecorations = new DecorationRepository();
            shopAquariums = new List<IAquarium>();

        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != "FreshwaterAquarium" && aquariumType != "SaltwaterAquarium")
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }
            else if (aquariumType == "FreshwaterAquarium")
            {
                shopAquariums.Add(new FreshwaterAquarium(aquariumName));
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                shopAquariums.Add(new SaltwaterAquarium(aquariumName));
            }
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != "Plant" && decorationType != "Ornament")
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }
            else if (decorationType == "Plant")
            {
                shopDecorations.Add(new Plant());
            }
            else if (decorationType == "Ornament")
            {
                shopDecorations.Add(new Ornament());
            }
            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium aquarium = shopAquariums.FirstOrDefault(el => el.Name == aquariumName);
            IFish fish = null;
            if (fishType != "FreshwaterFish" && fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException("Invalid fish type.");
            }
            if ((fishType == "FreshwaterFish" && aquarium.GetType().Name != "FreshwaterAquarium") || (fishType == "SaltwaterFish" && aquarium.GetType().Name != "SaltwaterAquarium"))
            {
                return "Water not suitable.";
            }
            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
                shopAquariums.FirstOrDefault(el => el.Name == aquariumName).AddFish(fish);
            }
            else
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
                shopAquariums.FirstOrDefault(el => el.Name == aquariumName).AddFish(fish);
            }
            return $"Successfully added {fishType} to {aquariumName}.";
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = shopAquariums.FirstOrDefault(el => el.Name == aquariumName);
            decimal sumDecors = aquarium.Fish.Sum(el => el.Price);
            decimal sumFishes = aquarium.Decorations.Sum(el => el.Price);

            return $"The value of Aquarium {aquariumName} is {sumDecors + sumFishes:F2}.";
        }

        public string FeedFish(string aquariumName)
        {
            shopAquariums.FirstOrDefault(el => el.Name == aquariumName).Feed();
            return $"Fish fed: { shopAquariums.FirstOrDefault(el => el.Name == aquariumName).Fish.Count}";

        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {

            if (shopDecorations.FindByType(decorationType) != null)
            {
                shopAquariums.FirstOrDefault(el => el.Name == aquariumName).AddDecoration(shopDecorations.FindByType(decorationType));
                shopDecorations.Remove(shopDecorations.FindByType(decorationType));
            }
            else
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }
            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            return string.Join(Environment.NewLine, shopAquariums.Select(el => el.GetInfo())).Trim();
        }
    }
}
