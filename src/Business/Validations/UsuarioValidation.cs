using Business.Models;
using FluentValidation;

namespace Business.Validations
{
    public class UsuarioValidation: AbstractValidator<Usuario>
    {
        public UsuarioValidation()
        {
            RuleFor(r => r.Nome)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .Length(2, 50).WithMessage("O campo {PropertyName} precisa ser entre {MinLength} e {MaxLength} caracteres!");

            RuleFor(r => r.Login)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .Length(2, 10).WithMessage("O campo {PropertyName} precisa ser entre {MinLength} e {MaxLength} caracteres!");

            RuleFor(r => r.Senha)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .Length(2, 10).WithMessage("O campo {PropertyName} precisa ser entre {MinLength} e {MaxLength} caracteres!");
        }
    }
}
