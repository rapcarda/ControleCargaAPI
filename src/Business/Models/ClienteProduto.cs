namespace Business.Models
{
    public class ClienteProduto: EntityBase
    {
        public long ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public long ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }

        public string CodigoBarra { get; set; }
    }
}
