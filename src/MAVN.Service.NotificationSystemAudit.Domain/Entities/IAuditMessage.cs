using System;
using MAVN.Service.NotificationSystemAudit.Domain.Enums;

namespace MAVN.Service.NotificationSystemAudit.Domain.Entities
{
    public interface IAuditMessage
    {
        Guid Id { get; set; }

        DateTime CreationTimestamp { get; set; }

        DateTime SentTimestamp { get; set; }

        string MessageId { get; set; }

        string MessageType { get; set; }

        string CustomerId { get; set; }

        string SubjectTemplateId { get; set; }

        string MessageTemplateId { get; set; }

        string Source { get; set; }

        CallType CallType { get; set; }

        FormattingStatus FormattingStatus { get; set; }

        string FormattingComment { get; set; }

        DeliveryStatus DeliveryStatus { get; set; }

        string DeliveryComment { get; set; }
    }
}
