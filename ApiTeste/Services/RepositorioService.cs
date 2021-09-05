using ApiTeste.Database;
using ApiTeste.Models.Entities;
using ApiTeste.Models.Requests;
using ApiTeste.Repositories.Interfaces;
using ApiTeste.Services.Interfaces;
using System.Collections.Generic;

namespace ApiTeste.Services
{
    public class RepositorioService : ServiceBase<Repositorio>, IRepositorioService
    {
        private IRepositorioRepository _repositorioRepository;

        public RepositorioService(SQLiteDbContext dbContext, IRepositorioRepository repositorioRepository)
            : base(dbContext, repositorioRepository)
        {
            _repositorioRepository = repositorioRepository;
        }

        public IList<Repositorio> FindAll(bool lazy = false)
        {
            return _repositorioRepository.FindAll(lazy);
        }

        public Repositorio Update(RepositorioRequest repositorioRequest, Repositorio repositorio)
        {
            repositorio.Nome = repositorioRequest.Nome;
            repositorio.Descricao = repositorioRequest.Descricao;

            _repositorioRepository.Update(repositorio);

            return repositorio;
        }

        public bool Exists(int idRepositorio)
        {
            return _repositorioRepository.Exists(idRepositorio);
        }
    }
}
