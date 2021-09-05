using System;
using System.Collections.Generic;

namespace ApiTeste.Models.Entities
{
    public class Repositorio
    {
        public Repositorio()
        {
            DataCriacao = DateTime.Now;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public int QuantidadeLikes { get; set; }
        public int UsuarioId { get; set; }

        //[JsonIgnore]
        public Usuario Usuario { get; set; }

        //[JsonIgnore]
        public virtual ICollection<PullRequest> PullRequests { get; set; }

        public decimal RetornaMediaDeLikesPorDia()
        {
            return QuantidadeLikes / (decimal)(DateTime.Now - DataCriacao).Days;
        }
    }
}
