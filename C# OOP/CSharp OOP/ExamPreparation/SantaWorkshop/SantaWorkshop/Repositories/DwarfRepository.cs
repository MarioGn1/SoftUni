using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Repositories
{
    public class DwarfRepository : IRepository<IDwarf>
    {
        private readonly List<IDwarf> dwarves;

        public DwarfRepository()
        {
            this.dwarves = new List<IDwarf>();
        }

        public IReadOnlyCollection<IDwarf> Models => dwarves;

        public void Add(IDwarf model)
        {
            this.dwarves.Add(model);
        }

        public IDwarf FindByName(string name)
        {
            return this.dwarves.FirstOrDefault(el => el.Name == name);
        }

        public bool Remove(IDwarf model)
        {
            return this.dwarves.Remove(model);
        }
    }
}
