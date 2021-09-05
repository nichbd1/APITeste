using ApiTeste.Models.Entities;
using ApiTeste.Models.Requests;
using System.Collections.Generic;

namespace ApiTeste.Services.Interfaces
{
    public interface IRepositorioService : IServiceBase<Repositorio>
    {
        IList<Repositorio> FindAll(bool lazy = false);
        Repositorio Update(RepositorioRequest repositorioRequest, Repositorio repositorio);
        bool Exists(int idRepositorio);
    }
}
