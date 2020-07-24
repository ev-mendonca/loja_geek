using Loja.Domain.Interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;
using Loja.Repository;

namespace Loja.Infra
{
    public static class SqlServerRepositoryDepedency
    {
        public static void AddSqlServerRepositoryDependency(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
