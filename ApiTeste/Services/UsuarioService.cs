using ApiTeste.Database;
using ApiTeste.Models.Entities;
using ApiTeste.Models.Requests;
using ApiTeste.Repositories.Interfaces;
using ApiTeste.Services.Interfaces;

namespace ApiTeste.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioService(SQLiteDbContext dbContext, IUsuarioRepository usuarioRepository)
            : base(dbContext, usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario Find(string email)
        {
            return _usuarioRepository.Find(email);
        }

        public Usuario Update(UsuarioRequest usuarioRequest, Usuario usuario)
        {
            usuario.Nome = usuarioRequest.Nome;            
            usuario.Email = usuarioRequest.Email;
            usuario.Senha = usuarioRequest.Senha;
            usuario.Telefone = usuarioRequest.Telefone;            

            _usuarioRepository.Update(usuario);

            return usuario;
        }

        public bool Exists(int usuarioId)
        {
            return _usuarioRepository.Exists(usuarioId);
        }
    }
}
