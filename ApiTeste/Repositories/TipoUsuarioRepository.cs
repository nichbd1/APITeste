using ApiTeste.Database;
using ApiTeste.Models.Entities;
using ApiTeste.Repositories.Interfaces;
using System.Linq;

namespace ApiTeste.Repositories
{
    public class TipoUsuarioRepository : RepositoryBase<TipoUsuario>, ITipoUsuarioRepository
    {
        private SQLiteDbContext _dbContext;

        public TipoUsuarioRepository(SQLiteDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
