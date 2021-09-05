using ApiTeste.Models.Entities;
using ApiTeste.Models.Requests;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ApiTeste.AppConfig.Swagger
{
    public static class SwaggerConfig
    {
        public static IServiceCollection ConfigureSwaggerDefault(this IServiceCollection services, IConfigurationSection options)
        {
            services.Configure<SwaggerOptionsUI>(options);
            var settings = options.Get<SwaggerOptionsUI>();
            
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = settings.ApiName,
                    Version = settings.Version,
                    Description = settings.Description
                });
            });

            return services;
        }

        public static void UseSwaggerDefault(this IApplicationBuilder app, IConfigurationSection options)
        {
            var settings = options.Get<SwaggerOptionsUI>();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", $"{settings.ApiName} {settings.Version}");
                c.RoutePrefix = "";
            });
        }
    }
}
