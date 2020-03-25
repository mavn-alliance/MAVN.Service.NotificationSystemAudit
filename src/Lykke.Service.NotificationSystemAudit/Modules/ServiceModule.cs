using Autofac;
using AutoMapper;
using Lykke.Service.NotificationSystemAudit.DomainServices.Subscribers;
using Lykke.Service.NotificationSystemAudit.Settings;
using Lykke.SettingsReader;

namespace Lykke.Service.NotificationSystemAudit.Modules
{
    public class ServiceModule : Module
    {
        private readonly IReloadingManager<AppSettings> _appSettings;

        public ServiceModule(IReloadingManager<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Mapper>().As<IMapper>().SingleInstance();

            builder.RegisterModule(new DomainServices.AutofacModule());

            RegisterRabbitMqSubscribers(builder);
        }

        private void RegisterRabbitMqSubscribers(ContainerBuilder builder)
        {
            builder.RegisterType<CreateAuditMessageSubscriber>()
                .As<IStartable>()
                .SingleInstance()
                .WithParameter("connectionString", _appSettings.CurrentValue.Rabbit.NotificationSystemAuditRabbitMq);

            builder.RegisterType<UpdateAuditMessageSubscriber>()
                .As<IStartable>()
                .SingleInstance()
                .WithParameter("connectionString", _appSettings.CurrentValue.Rabbit.NotificationSystemAuditRabbitMq);
        }
    }
}
