using System;
using Lykke.Service.NotificationSystemAudit.Domain.Enums;

namespace Lykke.Service.NotificationSystemAudit.Domain.Contracts
{
    public class UpdateAuditMessage
    {
        public string MessageId { get; set; }

        public DateTime SentTimestamp { get; set; }

        public DeliveryStatus DeliveryStatus { get; set; }

        public string DeliveryComment { get; set; }
    }
}
