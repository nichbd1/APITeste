using ApiTeste.Models.Entities;

namespace ApiTeste.Repositories.Interfaces
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario Find(string email);
        bool Exists(int usuarioId);
    }
}
