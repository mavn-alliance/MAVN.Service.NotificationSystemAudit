using JetBrains.Annotations;

namespace MAVN.Service.NotificationSystemAudit.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class NotificationSystemAuditSettings
    {
        public DbSettings Db { get; set; }
    }
}
