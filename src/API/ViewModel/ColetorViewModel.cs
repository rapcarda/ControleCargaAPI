using Business.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModel
{
    public class ColetorViewModel: BaseViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Número")]
        public int Numero { get; set; }

        [StringLength(250, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        [DisplayName("Observação")]
        public string Observacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Status")]
        public Status Status { get; set; }
    }
}
