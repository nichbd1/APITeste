using System;

namespace ApiTeste.Models.Entities
{
    public class PullRequest
    {
        public PullRequest()
        {
            DataCriacao = DateTime.Now;
        }

        public int Id { get; set; }
        public string Message { get; set; }
        public string FromBranch { get; set; }
        public string ToBranch { get; set; }
        public DateTime DataCriacao { get; set; }
        public int UsuarioId { get; set; }
        public int RepositorioId { get; set; }

        //[JsonIgnore]
        public Usuario Usuario { get; set; }
        //[JsonIgnore]
        public Repositorio Repositorio { get; set; }
    }
}
