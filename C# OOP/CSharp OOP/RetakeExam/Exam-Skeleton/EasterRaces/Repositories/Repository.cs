using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories
{
    public abstract class Repository<T>: IRepository<T>
    {
        private readonly List<T> colection;

        protected Repository()
        {
            this.colection = new List<T>();
        }

        public IReadOnlyCollection<T> Colection => this.colection;

        public void Add(T model)
        {
            if (!this.colection.Contains(model))
            {
                this.colection.Add(model);
            }
            
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return this.Colection;
        }

        public T GetByName(string name)
        {
            return this.colection.FirstOrDefault(el => el.GetType().Name == name);
        }

        public bool Remove(T model)
        {
            return this.colection.Remove(model);
        }
    }
}
