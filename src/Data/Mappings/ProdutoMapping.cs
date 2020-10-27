using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(p => p.Codigo)
                .IsRequired()
                .HasColumnType("numeric(5)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("Produto");
        }
    }
}
