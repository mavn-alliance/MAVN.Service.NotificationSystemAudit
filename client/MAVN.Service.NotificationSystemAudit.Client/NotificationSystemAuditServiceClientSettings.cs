using Lykke.SettingsReader.Attributes;

namespace MAVN.Service.NotificationSystemAudit.Client 
{
    /// <summary>
    /// NotificationSystemAudit client settings.
    /// </summary>
    public class NotificationSystemAuditServiceClientSettings 
    {
        /// <summary>Service url.</summary>
        [HttpCheck("api/isalive")]
        public string ServiceUrl {get; set;}
    }
}
