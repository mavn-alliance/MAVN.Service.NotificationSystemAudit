using JetBrains.Annotations;

namespace MAVN.Service.NotificationSystemAudit.Client
{
    /// <summary>
    /// NotificationSystemAudit client interface.
    /// </summary>
    [PublicAPI]
    public interface INotificationSystemAuditClient
    {
        // Make your app's controller interfaces visible by adding corresponding properties here.
        // NO actual methods should be placed here (these go to controller interfaces, for example - INotificationSystemAuditApi).
        // ONLY properties for accessing controller interfaces are allowed.

        /// <summary>Application Api interface</summary>
        INotificationSystemAuditApi Api { get; }
    }
}
