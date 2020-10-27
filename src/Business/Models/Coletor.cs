using Business.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models
{
    public class Coletor: EntityBase
    {
        public int Numero { get; set; }
        public string Observacao { get; set; }
        public string Imei { get; set; }
        public Status Status { get; set; }

        [Column("Utiliza_CC")]
        public YesNo UtilizaCC { get; set; }

        [Column("Last_Ficha_CC")]
        public DateTime? LastFichaCC { get; set; }

        [Column("Last_Sinc_CC")]
        public DateTime? LastSincCC { get; set; }
    }
}
