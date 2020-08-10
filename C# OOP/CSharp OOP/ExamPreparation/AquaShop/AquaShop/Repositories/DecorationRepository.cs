using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    class DecorationRepository : IRepository<Decoration>
    {
        private ICollection<IDecoration> decorations = new List<IDecoration>();

        public IReadOnlyCollection<Decoration> Models => (IReadOnlyCollection< Decoration>)decorations;

        public void Add(Decoration model)
        {
            decorations.Add(model);
        }

        public Decoration FindByType(string type)
        {
            return (Decoration)decorations.FirstOrDefault(el => el.GetType().Name == type);
            
        }

        public bool Remove(Decoration model)
        {
            if (this.decorations.Any(el => el.Equals(model)))
            {
                this.decorations.Remove(model);
                return true;
            }
            return false;
        }
    }
}
