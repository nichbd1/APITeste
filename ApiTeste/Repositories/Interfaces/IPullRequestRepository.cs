using ApiTeste.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTeste.Repositories.Interfaces
{
    public interface IPullRequestRepository : IRepositoryBase<PullRequest>
    {
        IList<PullRequest> FindByRepository(int idRepository);
        IList<PullRequest> FindByUsuario(int idUsuario);
    }
}
