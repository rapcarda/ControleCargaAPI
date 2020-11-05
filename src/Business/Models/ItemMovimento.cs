using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models
{
    public class ItemMovimento: EntityBase
    {
        public long MovimentoId { get; set; }
        public virtual Movimento Movimento { get; set; }
        [Column("cliprdID")]
        public long ClienteProdutoId { get; set; }
        public ClienteProduto ClienteProduto { get; set; }
        public int Qtd { get; set; }
    }
}
