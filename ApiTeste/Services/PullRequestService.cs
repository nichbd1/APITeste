using ApiTeste.Database;
using ApiTeste.Models.Entities;
using ApiTeste.Repositories.Interfaces;
using ApiTeste.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTeste.Services
{
    public class PullRequestService : ServiceBase<PullRequest>, IPullRequestService
    {
        private IPullRequestRepository _pullRequestRepository;

        public PullRequestService(SQLiteDbContext dbContext, IPullRequestRepository pullRequestRepository)
            : base(dbContext, pullRequestRepository)
        {
            _pullRequestRepository = pullRequestRepository;
        }

        public IList<PullRequest> FindByRepository(int idRepository)
        {
            return _pullRequestRepository.FindByRepository(idRepository);
        }

        public IList<PullRequest> FindByUsuario(int idUsuario)
        {
            return _pullRequestRepository.FindByUsuario(idUsuario);
        }

        public override void Add(PullRequest pullRequest)
        {
            if(pullRequest.ToBranch == pullRequest.FromBranch)
                throw new ArgumentException("You can't request a pull request for the same branch that you are pulling.");
            else
                base.Add(pullRequest);
        } 
    }
}
