using System;

namespace MAVN.Service.NotificationSystemAudit.Client.Models
{
    /// <summary>
    /// Represents audit message that have template parsing issues response model
    /// </summary>
    public class AuditMessageWithTemplateIssuesResponseModel
    {
        /// <summary>
        /// The Timestamp of when this message was created
        /// </summary>
        public DateTime CreationTimestamp { get; set; }

        /// <summary>
        /// The Timestamp of when this message was sent
        /// </summary>
        public DateTime SentTimestamp { get; set; }

        /// <summary>
        /// The MessageId of the message 
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        /// The MessageType
        /// </summary>
        public string MessageType { get; set; }

        /// <summary>
        /// The CustomerId this message is being sent to
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// The SubjectTemplateId used for this message
        /// </summary>
        public string SubjectTemplateId { get; set; }

        /// <summary>
        /// The MessageTemplateId used for this message
        /// </summary>
        public string MessageTemplateId { get; set; }

        /// <summary>
        /// The Source of this message
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// The CallType - Rabbit or Rest
        /// </summary>
        public string CallType { get; set; }

        /// <summary>
        /// Comment with details about FormattingStatus error, list of keys and etc
        /// </summary>
        public string FormattingComment { get; set; }

        /// <summary>
        /// Comment with details about DeliveryStatus error
        /// </summary>
        public string DeliveryComment { get; set; }
    }
}
