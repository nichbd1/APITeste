using ApiTeste.Database;
using ApiTeste.Models.Entities;
using ApiTeste.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ApiTeste.Repositories
{
    public class RepositorioRepository : RepositoryBase<Repositorio>, IRepositorioRepository
    {
        private SQLiteDbContext _dbContext;

        public RepositorioRepository(SQLiteDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Repositorio> FindAll(bool lazy = false)
        {
            if (lazy)
                return FindAll();

            var repositorios = _dbContext.Repositorios
                .ToList();

            return repositorios;
        }

        public bool Exists(int idRepositorio)
        {
            return _dbContext.Repositorios.Any(r => r.Id == idRepositorio);
        }
    }
}
