using System;

namespace ApiTeste.Models.Requests
{
    public class TipoUsuarioRequest
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
