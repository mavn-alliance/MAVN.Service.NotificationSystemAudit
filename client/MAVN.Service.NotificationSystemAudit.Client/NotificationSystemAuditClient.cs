using Lykke.HttpClientGenerator;

namespace MAVN.Service.NotificationSystemAudit.Client
{
    /// <summary>
    /// NotificationSystemAudit API aggregating interface.
    /// </summary>
    public class NotificationSystemAuditClient : INotificationSystemAuditClient
    {
        // Note: Add similar Api properties for each new service controller

        /// <summary>Interface to NotificationSystemAudit Api.</summary>
        public INotificationSystemAuditApi Api { get; private set; }

        /// <summary>C-tor</summary>
        public NotificationSystemAuditClient(IHttpClientGenerator httpClientGenerator)
        {
            Api = httpClientGenerator.Generate<INotificationSystemAuditApi>();
        }
    }
}
