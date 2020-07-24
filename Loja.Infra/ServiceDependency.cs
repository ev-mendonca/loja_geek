using Loja.Domain.Interfaces.Services;
using Loja.Service;
using Microsoft.Extensions.DependencyInjection;


namespace Loja.Infra
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}
