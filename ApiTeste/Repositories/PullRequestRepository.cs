using ApiTeste.Database;
using ApiTeste.Models.Entities;
using ApiTeste.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTeste.Repositories
{
    public class PullRequestRepository : RepositoryBase<PullRequest>, IPullRequestRepository
    {
        private SQLiteDbContext _dbContext;
        public PullRequestRepository(SQLiteDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<PullRequest> FindByRepository(int idRepository)
        {
            return _dbContext.PullRequests.Where<PullRequest>(p => p.RepositorioId == idRepository).ToList<PullRequest>();
        }

        public IList<PullRequest> FindByUsuario(int usuarioId)
        {
            return _dbContext.PullRequests.Where<PullRequest>(p => p.UsuarioId == usuarioId).ToList<PullRequest>();
        }
    }
}
