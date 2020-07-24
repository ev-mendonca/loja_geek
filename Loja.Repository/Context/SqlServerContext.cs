using Loja.Domain.Entities;
using Loja.Repository.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Loja.Repository.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);
        }
    }
}
