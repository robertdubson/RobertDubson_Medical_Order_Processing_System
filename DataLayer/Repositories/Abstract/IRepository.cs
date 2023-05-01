using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repositories
{
    public interface IRepository<TEntity, TKey>
    {
        public IEnumerable<TEntity> GetAll();

        public void Add(TEntity example);

        public TEntity GetByID(TKey ID);

        public void Update(TEntity example);

        public void Delete(TKey ID);

        public int NextID();

    }
}
