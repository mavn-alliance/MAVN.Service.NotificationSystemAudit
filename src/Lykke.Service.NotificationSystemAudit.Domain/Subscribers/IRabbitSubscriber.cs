using Autofac;
using Common;


namespace Lykke.Service.NotificationSystemAudit.Domain.Subscribers
{
    public interface IRabbitSubscriber<TMessage> : IStartable, IStopable
    {
    }
}
