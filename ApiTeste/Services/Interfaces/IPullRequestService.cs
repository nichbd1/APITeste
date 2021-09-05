using ApiTeste.Models.Entities;
using ApiTeste.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTeste.Services.Interfaces
{
    public interface IPullRequestService : IServiceBase<PullRequest>
    {
        public IList<PullRequest> FindByRepository(int idRepository);
        public IList<PullRequest> FindByUsuario(int idUsuario);
    }
}
