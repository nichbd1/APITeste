using ApiTeste.Models.Entities;
using ApiTeste.Models.Requests;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ApiTeste.AppConfig
{
    public static class AutoMapperConfig
    {
        public static void AddMapping(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UsuarioRequest, Usuario>();
                cfg.CreateMap<TipoUsuarioRequest, TipoUsuario>();
                cfg.CreateMap<RepositorioRequest, Repositorio>();
                cfg.CreateMap<PullRequestRequest, PullRequest>();
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
