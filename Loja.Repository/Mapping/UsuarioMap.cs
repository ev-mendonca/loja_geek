using Loja.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loja.Repository.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");

            builder.HasKey(u => u.ID);

            builder.Property(u => u.ID)
                .HasColumnName("id");
            
            builder.Property(u => u.Email)
                .IsRequired()
                .HasColumnName("email");

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasColumnName("nome");

            builder.Property(u => u.Senha)
                .HasColumnName("senha");

            builder.Property(u => u.Login)
                .IsRequired()
                .HasColumnName("login");

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.HasIndex(x => x.Login)
                .IsUnique();
        }
    }
}
