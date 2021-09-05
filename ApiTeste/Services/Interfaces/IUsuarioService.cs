using ApiTeste.Models.Entities;
using ApiTeste.Models.Requests;
using System.Collections;

namespace ApiTeste.Services.Interfaces
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        Usuario Find(string email);
        Usuario Update(UsuarioRequest usuarioRequest, Usuario usuario);
        bool Exists(int usuarioId);
    }
}
