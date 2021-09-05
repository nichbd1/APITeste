using ApiTeste.Database;
using ApiTeste.Models.Entities;
using ApiTeste.Models.Requests;
using ApiTeste.Repositories.Interfaces;
using ApiTeste.Services.Interfaces;

namespace ApiTeste.Services
{
    public class TipoUsuarioService : ServiceBase<TipoUsuario>, ITipoUsuarioService
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuarioService(SQLiteDbContext dbContext, ITipoUsuarioRepository tipoUsuarioRepository)
            : base(dbContext, tipoUsuarioRepository)
        {
            _tipoUsuarioRepository = tipoUsuarioRepository;
        }
    }
}
