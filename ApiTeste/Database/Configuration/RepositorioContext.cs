using ApiTeste.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ApiTeste.Database.Configuration
{
    public class RepositorioContext : IEntityTypeConfiguration<Repositorio>
    {
        public void Configure(EntityTypeBuilder<Repositorio> builder)
        {
            builder.HasKey(prop => prop.Id);

            builder
                .HasOne(p => p.Usuario)
                .WithMany(p => p.Repositories)
                .HasForeignKey(p => p.UsuarioId);

            builder.HasData(new Repositorio
            {
                Id = 1,
                Nome = "api_rest_c#",
                Descricao = "REST API feita com C#",
                DataCriacao = DateTime.Parse("Jan 1, 2020"),
                QuantidadeLikes = 1350,
                UsuarioId = 1
            });
        }
    }
}
