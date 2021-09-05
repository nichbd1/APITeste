using ApiTeste.Database;
using ApiTeste.Repositories;
using ApiTeste.Services.Interfaces;
using System.Collections.Generic;

namespace ApiTeste.Services
{
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private IRepositoryBase<TEntity> _repository;
        private SQLiteDbContext _dbContext;

        public ServiceBase(SQLiteDbContext dbContext, IRepositoryBase<TEntity> repository)
        {
            _dbContext = dbContext;
            _repository = repository;
        }
        public virtual void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public IList<TEntity> FindAll()
        {
            return _repository.FindAll();
        }

        public TEntity FindById(int id)
        {
            return _repository.FindById(id);
        }

        public TEntity Delete(TEntity entity)
        {
            _repository.Delete(entity);

            return entity;
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }
    }
}
