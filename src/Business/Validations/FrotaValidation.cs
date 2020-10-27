using Business.Models;
using FluentValidation;

namespace Business.Validations
{
    public class FrotaValidation: AbstractValidator<Frota>
    {
        public FrotaValidation()
        {
            RuleFor(r => r.Placa)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .Length(2, 10).WithMessage("O campo {PropertyName} precisa ser entre {MinLength} e {MaxLength} caracteres!");

            RuleFor(r => r.Descricao)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ser entre {MinLength} e {MaxLength} caracteres!");
        }
    }
}
