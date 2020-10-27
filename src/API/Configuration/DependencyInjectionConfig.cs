using Business.Interfaces.Repository;
using Business.Interfaces.Service;
using Business.Interfaces.Shared;
using Business.Notifications;
using Business.Services;
using Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<INotificator, Notificator>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IClienteProdutoRepository, ClienteProdutoRepository>();
            services.AddScoped<IClienteProdutoService, ClienteProdutoService>();
            services.AddScoped<IColetorRepository, ColetorRepository>();
            services.AddScoped<IColetorService, ColetorService>();
            services.AddScoped<IFrotaRepository, FrotaRepository>();
            services.AddScoped<IFrotaService, FrotaService>();

            return services;
        }
    }
}
