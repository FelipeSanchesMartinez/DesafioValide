using MediatR;

namespace DesafioValide.Domain.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        public List<DomainNotification> Notifications;

        public bool HasNotification
        {
            get
            {
                return Notifications.Any();
            }
        }
        public DomainNotificationHandler()
        {
            Notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            Notifications.Add(notification);
            return Task.CompletedTask;
        }


    }
}
