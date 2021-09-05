using ApiTeste.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ApiTeste.Database.Configuration
{
    public class UsuarioContext : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(prop => prop.Id);

            builder
                .HasOne(p => p.TipoUsuario)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(p => p.TipoUsuarioId);

            builder.HasData(new Usuario
            {
                Id = 1,
                Nome = "Usuário Admin",
                Email = "usuarioadmin@ecs.com.br",
                Senha = "123456",
                DataNascimento = DateTime.Parse("Jul 30, 2000"),
                Telefone = "51 3333-3333",
                TipoUsuarioId = 1
            });
        }
    }
}
