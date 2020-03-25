using System;
using Lykke.Service.NotificationSystemAudit.Domain.Enums;

namespace Lykke.Service.NotificationSystemAudit.Domain.Contracts
{
    public class CreateAuditMessage
    {
        public DateTime Timestamp { get; set; }
         
        public string MessageId { get; set; }
         
        public string MessageType { get; set; }
         
        public string CustomerId { get; set; }
         
        public string SubjectTemplateId { get; set; }
         
        public string MessageTemplateId { get; set; }
         
        public string Source { get; set; }
         
        public CallType CallType { get; set; }
         
        public FormattingStatus FormattingStatus { get; set; }
         
        public string FormattingComment { get; set; }

        public string MessageGroupId { get; set; }
    }
}
