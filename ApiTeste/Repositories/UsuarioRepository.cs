using ApiTeste.Database;
using ApiTeste.Models.Entities;
using ApiTeste.Repositories.Interfaces;
using System.Linq;

namespace ApiTeste.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        private SQLiteDbContext _dbContext;

        public UsuarioRepository(SQLiteDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Usuario Find(string email)
        {
            return FindAll().SingleOrDefault(u => u.Email == email);
        }

        public bool Exists(int usuarioId)
        {
            return _dbContext.Usuarios.Any(u => u.Id == usuarioId);
        }
    }
}
