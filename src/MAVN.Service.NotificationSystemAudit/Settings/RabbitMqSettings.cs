using Lykke.SettingsReader.Attributes;

namespace MAVN.Service.NotificationSystemAudit.Settings
{
    public class RabbitMqSettings
    {
        [AmqpCheck]
        public string NotificationSystemAuditRabbitMq { get; set; }
    }
}
