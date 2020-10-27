using System.Collections.Generic;

namespace Business.Models
{
    public class Cliente: EntityBase
    {
        public Cliente()
        {
            ClienteProdutos = new List<ClienteProduto>();
        }

        public int Codigo { get; set; }
        public string Descricao { get; set; }

        public ICollection<ClienteProduto> ClienteProdutos { get; set; }
    }
}
