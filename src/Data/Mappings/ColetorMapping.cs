using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    class ColetorMapping : IEntityTypeConfiguration<Coletor>
    {
        public void Configure(EntityTypeBuilder<Coletor> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(p => p.Numero)
                .IsRequired()
                .HasColumnType("numeric(3)");

            builder.Property(p => p.Observacao)
                .HasColumnType("varchar(250)");

            builder.Property(p => p.Imei)
                .IsRequired()
                .HasColumnType("varchar(25)");

            builder.Property(p => p.Status)
                .IsRequired()
                .HasColumnType("numeric(1)");

            builder.Property(p => p.UtilizaCC)
                .IsRequired()
                .HasColumnName("Utiliza_CC")
                .HasColumnType("numeric(1)");

            builder.Property(p => p.LastFichaCC)
                .HasColumnName("Last_Ficha_CC")
                .HasColumnType("datetime");

            builder.Property(p => p.LastSincCC)
                .HasColumnName("Last_Sinc_CC")
                .HasColumnType("datetime");

            builder.ToTable("Coletor");
        }
    }
}
