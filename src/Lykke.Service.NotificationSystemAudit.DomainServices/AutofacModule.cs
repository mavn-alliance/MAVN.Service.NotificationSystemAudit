using Autofac;
using Lykke.Service.NotificationSystemAudit.Domain.Services;
using Lykke.Service.NotificationSystemAudit.DomainServices.Services;

namespace Lykke.Service.NotificationSystemAudit.DomainServices
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuditMessageService>().As<IAuditMessageService>().SingleInstance();
        }
    }
}
