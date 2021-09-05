using ApiTeste.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ApiTeste.Database.Configuration
{
    public class PullRequestContext : IEntityTypeConfiguration<PullRequest>
    {
        public void Configure(EntityTypeBuilder<PullRequest> builder)
        {
            builder.HasKey(prop => prop.Id);

            builder.HasOne(p => p.Usuario)
                .WithMany(p => p.PullRequests)
                .HasForeignKey(p => p.UsuarioId);
            builder.HasOne(p => p.Repositorio)
                .WithMany(p => p.PullRequests)
                .HasForeignKey(p => p.RepositorioId);

        }
    }
}
