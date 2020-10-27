using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.User
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(10, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(10, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres!", MinimumLength = 2)]
        public string Password { get; set; }
    }
}
