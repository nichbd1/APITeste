using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiTeste.Models.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public int TipoUsuarioId { get; set; }

        [JsonIgnore]
        public TipoUsuario TipoUsuario { get; set; }

        [JsonIgnore]
        public ICollection<Repositorio> Repositories { get; set; }
        [JsonIgnore]
        public ICollection<PullRequest> PullRequests { get; set; }
    }
}
