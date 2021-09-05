using System.Collections.Generic;

namespace ApiTeste.Services.Interfaces
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        TEntity FindById(int id);
        IList<TEntity> FindAll();
        void Update(TEntity entity);
        TEntity Delete(TEntity entity);
    }
}
