using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace DataLayer.Repositories
{
    public class GenericRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        private readonly DbContext Context;

        public DbSet<TEntity> _DbSet;

        public GenericRepository(DbContext context)
        {

            Context = context;

            _DbSet = Context.Set<TEntity>();

        }

        public void Add(TEntity example)
        {
            _DbSet.Add(example);
        }

        public void Delete(TKey ID)
        {
            _DbSet.Remove(Context.Set<TEntity>().Find(ID));
        }

        public void Delete(TEntity example)
        {
            Context.Entry(example).State = EntityState.Deleted;
            Context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _DbSet;
        }

        public TEntity GetByID(TKey ID)
        {
            return _DbSet.Find(ID);
        }

        public void Update(TEntity example)
        {
            Context.Entry(example).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
