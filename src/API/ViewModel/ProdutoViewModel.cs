using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModel
{
    public class ProdutoViewModel: BaseViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(5, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        [DisplayName("Código")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
