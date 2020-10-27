using Business.Models;
using FluentValidation;

namespace Business.Validations
{
    public class ClienteProdutoValidation: AbstractValidator<ClienteProduto>
    {
        public ClienteProdutoValidation()
        {
            RuleFor(r => r.ClienteId)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido!");

            RuleFor(r => r.ProdutoId)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido!");
        }
    }
}
