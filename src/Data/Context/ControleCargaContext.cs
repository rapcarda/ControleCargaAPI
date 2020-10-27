using Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Context
{
    public class ControleCargaContext: DbContext
    {
        public ControleCargaContext(DbContextOptions<ControleCargaContext> options): base(options)
        {
        }

        /*DBSets*/
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* Em versões anteiores, era preciso dar o Aplly para cada entidade e classe de mapping. */
            /* Agora, ao dar o Aplly from assembly, o EF já busca o contexto, pega todos os dbsets do contexto */
            /* procura por arquivos que herdam de IEntityTypeConfiguration da entidade do dbset, e cria tudo de uma vez */
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ControleCargaContext).Assembly);

            /*Desativar o cascade no delete*/
            foreach (var relations in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relations.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
