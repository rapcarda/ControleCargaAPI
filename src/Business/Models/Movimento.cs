using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models
{
    public class Movimento: EntityBase
    {
        public long ColetorId { get; set; }
        public virtual Coletor Coletor { get; set; }
        public long UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public long FrotaId { get; set; }
        public virtual Frota Frota { get; set; }
        [Column("Coletor_Chave")]
        public string ColetorChave { get; set; }
        [Column("Coletor_App")]
        public string ColetorApp { get; set; }
        [Column("Coletor_Doc")]
        public int ColetorDoc { get; set; }
        [Column("Data_Hora_Gravacao")]
        public DateTime? DataHoraGravacao { get; set; }
        [Column("Data_Hora_Inicial")]
        public DateTime? DataHoraInicial { get; set; }
        [Column("Data_Hora_Final")]
        public DateTime? DataHoraFinal { get; set; }
        public string Obs { get; set; }

        public IEnumerable<ItemMovimento> ItemMovimento { get; set; }
    }
}
