using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModel
{
    public class ClienteProdutoViewModel: BaseViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public long ClienteId { get; set; }

        [ScaffoldColumn(false)]
        public string ClienteDescricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public long ProdutoId { get; set; }

        [ScaffoldColumn(false)]
        public string ProdutoDescricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        [DisplayName("Código de Barra")]
        public string CodigoBarra { get; set; }
    }
}
