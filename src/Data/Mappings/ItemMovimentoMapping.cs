using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class ItemMovimentoMapping : IEntityTypeConfiguration<ItemMovimento>
    {
        public void Configure(EntityTypeBuilder<ItemMovimento> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.MovimentoId)
                .IsRequired();

            builder.Property(c => c.ClienteProdutoId)
                .IsRequired()
                .HasColumnName("cliprdID");

            builder.Property(p => p.Qtd)
                .IsRequired()
                .HasColumnType("numeric(5)");

            builder.ToTable("Item_Movimento");
        }
    }
}
