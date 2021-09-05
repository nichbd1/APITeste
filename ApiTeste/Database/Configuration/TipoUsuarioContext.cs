using ApiTeste.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ApiTeste.Database.Configuration
{
    public class TipoUsuarioContext : IEntityTypeConfiguration<TipoUsuario>
    {
        public void Configure(EntityTypeBuilder<TipoUsuario> builder)
        {
            builder.HasKey(prop => prop.Id);

            builder.HasData(new TipoUsuario
            {
                Id = 1,
                Nome = "Admin",
                Descricao = "Administrador"
            });
        }
    }
}
