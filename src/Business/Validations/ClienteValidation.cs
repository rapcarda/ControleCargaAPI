using Business.Models;
using FluentValidation;

namespace Business.Validations
{
    public class ClienteValidation: AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(r => r.Codigo)
                .NotNull()
                .WithMessage("O campo {PropertyName} precisa ser fornecido!");

            RuleFor(r => r.Descricao)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ser entre {MinLength} e {MaxLength} caracteres!");
        }
    }
}
