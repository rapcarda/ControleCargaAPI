using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Codigo)
                .IsRequired()
                .HasColumnType("numeric(5)");

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Login)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(p => p.Senha)
                .IsRequired()
                .HasColumnType("varchar(10)");
        }
    }
}
