using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiTeste.Models.Entities
{
    public class TipoUsuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        [JsonIgnore]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
