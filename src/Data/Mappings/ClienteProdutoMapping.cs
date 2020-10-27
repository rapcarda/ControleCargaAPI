using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    class ClienteProdutoMapping : IEntityTypeConfiguration<ClienteProduto>
    {
        public void Configure(EntityTypeBuilder<ClienteProduto> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.ClienteId)
                .IsRequired();

            builder.Property(c => c.ProdutoId)
                .IsRequired();

            builder.Property(p => p.CodigoBarra)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.HasOne(c => c.Cliente)
                .WithMany(p => p.ClienteProdutos)
                .HasForeignKey(c => c.ClienteId);

            builder.HasOne(c => c.Produto)
                .WithMany(p => p.ClientesProduto)
                .HasForeignKey(c => c.ProdutoId);

            builder.ToTable("ClienteProduto");
        }
    }
}
