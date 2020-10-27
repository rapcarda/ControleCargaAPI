using Business.Interfaces.Shared;
using Business.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly INotificator _notificator;

        public BaseController(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (IsValidaOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            };

            return BadRequest(new
            {
                success = false,
                errors = _notificator.GetNotifications().Select(x => x.Message)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
                NotifyErrorModelInvalid(modelState);

            return CustomResponse();
        }

        protected void NotifyErrorModelInvalid(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);

            foreach (var error in errors)
            {
                var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotifyError(errorMsg);
            }
        }

        protected void NotifyError(string error)
        {
            _notificator.Handle(new Notification(error));
        }

        private bool IsValidaOperation()
        {
            return !_notificator.HasNotification();
        }
    }
}
