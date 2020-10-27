using Business.Models;
using FluentValidation;

namespace Business.Validations
{
    public class ColetorValidation: AbstractValidator<Coletor>
    {
        public ColetorValidation()
        {
            RuleFor(r => r.Numero)
                .NotNull()
                .WithMessage("O campo {PropertyName} precisa ser fornecido!");

            RuleFor(r => r.Imei)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .Length(2, 25).WithMessage("O campo {PropertyName} precisa ser entre {MinLength} e {MaxLength} caracteres!");

            RuleFor(r => r.Status)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .IsInEnum().WithMessage("Campo {PropertyName} inválido.");

            RuleFor(r => r.UtilizaCC)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .IsInEnum().WithMessage("Campo {PropertyName} inválido.");
        }
    }
}
