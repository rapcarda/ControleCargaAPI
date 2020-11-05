using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    class MovimentoMapping : IEntityTypeConfiguration<Movimento>
    {
        public void Configure(EntityTypeBuilder<Movimento> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.ColetorId)
                .IsRequired();

            builder.Property(c => c.UsuarioId)
                .IsRequired();

            builder.Property(c => c.FrotaId)
                .IsRequired();

            builder.Property(p => p.ColetorChave)
                .HasColumnName("Coletor_Chave")
                .HasColumnType("varchar(20)");

            builder.Property(p => p.ColetorApp)
                .HasColumnName("Coletor_App")
                .HasColumnType("varchar(15)");

            builder.Property(p => p.ColetorDoc)
                .HasColumnName("Coletor_Doc")
                .HasColumnType("numeric");

            builder.Property(p => p.DataHoraGravacao)
                .HasColumnName("Data_Hora_Gravacao")
                .HasColumnType("datetime");

            builder.Property(p => p.DataHoraInicial)
                .IsRequired()
                .HasColumnName("Data_Hora_Inicial")
                .HasColumnType("datetime");

            builder.Property(p => p.DataHoraFinal)
                .HasColumnName("Data_Hora_Final")
                .HasColumnType("datetime");

            builder.Property(p => p.Obs)
                .HasColumnType("varchar(500)");

            builder.ToTable("Movimento");
        }
    }
}
