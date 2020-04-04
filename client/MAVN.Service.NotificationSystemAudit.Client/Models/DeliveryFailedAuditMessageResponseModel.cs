using System;

namespace MAVN.Service.NotificationSystemAudit.Client.Models
{
    /// <summary>
    /// Represents info for a failed audit message
    /// </summary>
    public class DeliveryFailedAuditMessageResponseModel
    {
        /// <summary>
        /// The CreationTimestamp
        /// </summary>
        public DateTime CreationTimestamp { get; set; }

        /// <summary>
        /// The FromSentTimestamp
        /// </summary>
        public DateTime SentTimestamp { get; set; }

        /// <summary>
        /// The MessageId
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        /// The MessageType
        /// </summary>
        public string MessageType { get; set; }

        /// <summary>
        /// The CustomerId of the receiver
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// The SubjectTemplateId
        /// </summary>
        public string SubjectTemplateId { get; set; }

        /// <summary>
        /// The MessageTemplateId
        /// </summary>
        public string MessageTemplateId { get; set; }

        /// <summary>
        /// The Source of the message
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// The CallType that states from where the method to send the message was called
        /// </summary>
        public string CallType { get; set; }

        /// <summary>
        /// The DeliveryComment containing any info on why the delivery failed
        /// </summary>
        public string DeliveryComment { get; set; }
    }
}
