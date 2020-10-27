using Business.Interfaces.Service;
using Business.Interfaces.Shared;
using Business.Models;
using Business.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace Business.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : EntityBase
    {
        private readonly INotificator _notificador;

        public BaseService(INotificator notificador)
        {
            _notificador = notificador;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var val in validationResult.Errors)
            {
                Notify(val.ErrorMessage);
            }
        }

        protected void Notify(string mensagem)
        {
            _notificador.Handle(new Notification(mensagem));
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entidade) where TV : AbstractValidator<TE> where TE : EntityBase
        {
            var validator = validation.Validate(entidade);

            if (validator.IsValid)
                return true;

            Notify(validator);
            return false;
        }

        public void Dispose()
        {
        }
    }
}
