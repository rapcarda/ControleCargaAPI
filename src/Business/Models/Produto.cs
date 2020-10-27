using System.Collections.Generic;

namespace Business.Models
{
    public class Produto: EntityBase
    {
        public Produto()
        {
            ClientesProduto = new List<ClienteProduto>();
        }

        public int Codigo { get; set; }
        public string Descricao { get; set; }

        public ICollection<ClienteProduto> ClientesProduto { get; set; }
    }
}
