using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTeste.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        TEntity FindById(int id);
        IList<TEntity> FindAll();
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
