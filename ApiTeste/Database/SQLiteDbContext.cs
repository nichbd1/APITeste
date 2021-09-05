using ApiTeste.Database.Configuration;
using ApiTeste.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ApiTeste.Database
{
    public class SQLiteDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Repositorio> Repositorios { get; set; }
        public DbSet<TipoUsuario> TiposUsuarios { get; set; }        
        public DbSet<PullRequest> PullRequests { get; set; }        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new TipoUsuarioContext());
            builder.ApplyConfiguration(new UsuarioContext());
            builder.ApplyConfiguration(new RepositorioContext());
            builder.ApplyConfiguration(new PullRequestContext());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=sqlitedemo.db");
    }
}
