using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.NotificationSystemAudit.Settings
{
    public class RabbitMqSettings
    {
        [AmqpCheck]
        public string NotificationSystemAuditRabbitMq { get; set; }
    }
}
