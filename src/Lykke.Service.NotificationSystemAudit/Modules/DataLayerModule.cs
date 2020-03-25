using Autofac;
using Lykke.Common.MsSql;
using Lykke.Service.NotificationSystemAudit.Domain.Repositories;
using Lykke.Service.NotificationSystemAudit.MsSqlRepositories;
using Lykke.Service.NotificationSystemAudit.MsSqlRepositories.Repositories;
using Lykke.Service.NotificationSystemAudit.Settings;
using Lykke.SettingsReader;

namespace Lykke.Service.NotificationSystemAudit.Modules
{
    public class DataLayerModule : Module
    {
        private readonly string _connectionString;

        public DataLayerModule(IReloadingManager<AppSettings> appSettings)
        {
            _connectionString = appSettings.CurrentValue.NotificationSystemAuditService.Db.DataConnString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMsSql(
                _connectionString,
                connString => new AuditMessageContext(connString, false),
                dbConn => new AuditMessageContext(dbConn));

            builder.RegisterType<AuditMessageRepository>()
                .As<IAuditMessageRepository>()
                .SingleInstance();
        }
    }
}
