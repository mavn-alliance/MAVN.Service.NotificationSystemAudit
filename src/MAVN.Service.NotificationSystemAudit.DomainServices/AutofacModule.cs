using Autofac;
using MAVN.Service.NotificationSystemAudit.Domain.Services;
using MAVN.Service.NotificationSystemAudit.DomainServices.Services;

namespace MAVN.Service.NotificationSystemAudit.DomainServices
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuditMessageService>().As<IAuditMessageService>().SingleInstance();
        }
    }
}
