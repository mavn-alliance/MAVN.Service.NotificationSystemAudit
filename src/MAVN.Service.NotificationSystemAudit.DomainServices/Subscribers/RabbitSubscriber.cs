using System;
using System.Threading.Tasks;
using Common.Log;
using Lykke.Common.Log;
using Lykke.RabbitMqBroker;
using Lykke.RabbitMqBroker.Subscriber;
using MAVN.Service.NotificationSystemAudit.Domain.Subscribers;

namespace MAVN.Service.NotificationSystemAudit.DomainServices.Subscribers
{
    public abstract class RabbitSubscriber<TMessage> : IRabbitSubscriber<TMessage>
    {
        protected readonly ILog Log;
        private RabbitMqSubscriber<TMessage> _subscriber;
        private readonly ILogFactory _logFactory;

        private readonly string _connectionString;
        private readonly string _exchangeName;

        protected RabbitSubscriber(string connectionString, string exchangeName, ILogFactory logFactory)
        {
            Log = logFactory.CreateLog(this);
            _logFactory = logFactory;
            _connectionString = connectionString;
            _exchangeName = exchangeName;
        }

        public void Start()
        {
            var rabbitMqSubscriptionSettings = RabbitMqSubscriptionSettings.ForSubscriber(_connectionString,
                    _exchangeName,
                    "notificationsystemaudit")
                .MakeDurable();

            _subscriber = new RabbitMqSubscriber<TMessage>(
                    _logFactory,
                    rabbitMqSubscriptionSettings,
                    new ResilientErrorHandlingStrategy(
                        _logFactory,
                        rabbitMqSubscriptionSettings,
                        TimeSpan.FromSeconds(10)))
                .SetMessageDeserializer(new JsonMessageDeserializer<TMessage>())
                .Subscribe(ProcessMessageAsync)
                .CreateDefaultBinding()
                .Start();
        }

        public void Stop()
        {
            _subscriber.Stop();
        }

        public void Dispose()
        {
            _subscriber.Dispose();
        }

        protected abstract Task ProcessMessageAsync(TMessage message);
    }
}
