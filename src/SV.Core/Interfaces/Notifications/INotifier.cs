using SV.Core.Notifications;
using System.Collections.Generic;

namespace SV.Core.Interfaces.Notifications
{
    public interface INotifier
    {
        bool HasNotifications();
        void Handle(Notification notification);
        List<Notification> GetNotifications();
    }
}
