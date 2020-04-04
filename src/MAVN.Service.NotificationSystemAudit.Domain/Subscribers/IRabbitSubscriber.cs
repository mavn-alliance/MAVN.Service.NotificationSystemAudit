using Autofac;
using Common;


namespace MAVN.Service.NotificationSystemAudit.Domain.Subscribers
{
    public interface IRabbitSubscriber<TMessage> : IStartable, IStopable
    {
    }
}
