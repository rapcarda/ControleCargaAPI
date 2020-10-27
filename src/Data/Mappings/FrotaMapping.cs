using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    class FrotaMapping : IEntityTypeConfiguration<Frota>
    {
        public void Configure(EntityTypeBuilder<Frota> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(p => p.Placa)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(100)");

            builder.ToTable("Frota");
        }
    }
}
