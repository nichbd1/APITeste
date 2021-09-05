using System;

namespace ApiTeste.Models.Requests
{
    public class RepositorioRequest
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
    }
}

