using ApiTeste.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ApiTeste.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly SQLiteDbContext context;

        public RepositoryBase(SQLiteDbContext context)
        {
            this.context = context;
        }

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.Entry(entity).State = EntityState.Added;

            context.SaveChanges();
        }

        public TEntity FindById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public IList<TEntity> FindAll()
        {
            var query = from e in context.Set<TEntity>() select e;
            return query.ToList();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }
    }
}
