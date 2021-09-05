using ApiTeste.Database;
using ApiTeste.Repositories;
using ApiTeste.Repositories.Interfaces;
using ApiTeste.Services;
using ApiTeste.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApiTeste.AppConfig
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<DbContext, SQLiteDbContext>();

            //services
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IRepositorioService, RepositorioService>();
            services.AddTransient<ITipoUsuarioService, TipoUsuarioService>();
            services.AddTransient<IPullRequestService, PullRequestService>();

            ////repositories
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IRepositorioRepository, RepositorioRepository>();
            services.AddTransient<ITipoUsuarioRepository, TipoUsuarioRepository>();
            services.AddTransient<IPullRequestRepository, PullRequestRepository>();
        }
    }
}
