using JetBrains.Annotations;

namespace Lykke.Service.NotificationSystemAudit.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class NotificationSystemAuditSettings
    {
        public DbSettings Db { get; set; }
    }
}
