using Business.Models;
using FluentValidation;

namespace Business.Validations
{
    public class ProdutoValidation: AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            RuleFor(r => r.Codigo)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido!");

            RuleFor(r => r.Descricao)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ser entre {MinLength} e {MaxLength} caracteres!");
        }
    }
}
