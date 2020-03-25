using System;
using Lykke.Service.NotificationSystemAudit.Domain.Enums;

namespace Lykke.Service.NotificationSystemAudit.Domain.Contracts
{
    public class DeliveryFailedAuditMessageContract
    {
        public DateTime CreationTimestamp { get; set; }
         
        public DateTime SentTimestamp { get; set; }
         
        public string MessageId { get; set; }
         
        public string MessageType { get; set; }
         
        public string CustomerId { get; set; }
         
        public string SubjectTemplateId { get; set; }
         
        public string MessageTemplateId { get; set; }
         
        public string Source { get; set; }
         
        public CallType CallType { get; set; }
         
        public string DeliveryComment { get; set; }
    }
}
