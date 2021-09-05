using System;

namespace ApiTeste.Models.Responses
{
    public class RepositorioResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public int QuantidadeLikes { get; set; }
        public decimal MediaDeLikesPorDia { get; set; }
        public int UsuarioId { get; set; }
    }
}

