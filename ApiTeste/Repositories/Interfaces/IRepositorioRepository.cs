using ApiTeste.Models.Entities;
using System.Collections.Generic;

namespace ApiTeste.Repositories.Interfaces
{
    public interface IRepositorioRepository : IRepositoryBase<Repositorio>
    {
        IList<Repositorio> FindAll(bool lazy = false);
        bool Exists(int idRepositorio);
    }
}
