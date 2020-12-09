using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        private ICollection<T> models;
        public Repository()
        {
            models = new List<T>();
        }
        public void Add(T model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return models.ToList().AsReadOnly();
        }

        public T GetByName(string name)
        {
            T entity = models.FirstOrDefault(n => n.GetType().Name == name);
            return entity;
        }

        public bool Remove(T model)
        {
            return models.Remove(model);
        }
    }
}
