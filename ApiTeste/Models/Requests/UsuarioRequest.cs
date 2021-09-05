using System;

namespace ApiTeste.Models.Requests
{
    public class UsuarioRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public int TipoUsuarioId { get; set; }
    }
}
