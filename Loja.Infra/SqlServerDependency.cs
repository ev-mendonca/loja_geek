using Loja.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Loja.Infra
{
    public static class SqlServerDependency
    {
        public static void AddSqlServerDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlServerContext>(options => options
                            .UseSqlServer(configuration.GetConnectionString("Default")));
        }
    }
}
