using MediatR;

namespace DesafioValide.Domain.Notifications
{
    public class DomainNotification : INotification
    {
        public DomainNotification(string type, string value)
        {
            Type = type;
            Value = value;
        }

        public string Type { get; set; }
        public string Value { get; set; }
    }
}
