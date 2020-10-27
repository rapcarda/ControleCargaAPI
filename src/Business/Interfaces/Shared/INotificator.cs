using Business.Notifications;
using System.Collections.Generic;

namespace Business.Interfaces.Shared
{
    public interface INotificator
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
