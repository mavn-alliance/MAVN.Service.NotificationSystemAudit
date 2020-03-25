using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lykke.Service.NotificationSystemAudit.Domain.Entities;
using Lykke.Service.NotificationSystemAudit.Domain.Enums;

namespace Lykke.Service.NotificationSystemAudit.MsSqlRepositories.Entities
{
    [Table("audit_messages")]
    public class AuditMessage : IAuditMessage
    {
        [Column("id")]
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Column("creation_timestamp")]
        [Required]
        public DateTime CreationTimestamp { get; set; }

        [Column("sent_timestamp")]
        [Required]
        public DateTime SentTimestamp { get; set; }

        [Column("message_id")]
        [Required]
        [MaxLength(100)]
        public string MessageId { get; set; }

        [Column("message_type")]
        [Required]
        [MaxLength(30)]
        public string MessageType { get; set; }

        [Column("customer_id")]
        [Required]
        [MaxLength(100)]
        public string CustomerId { get; set; }

        [Column("subject_template_id")]
        [MaxLength(100)]
        public string SubjectTemplateId { get; set; }

        [Column("message_template_id")]
        [Required]
        [MaxLength(100)]
        public string MessageTemplateId { get; set; }

        [Column("source")]
        [Required]
        [MaxLength(100)]
        public string Source { get; set; }

        [Column("call_type")]
        [Required]
        [MaxLength(20)]
        public CallType CallType { get; set; }

        [Column("formatting_status")]
        [Required]
        [MaxLength(40)]
        public FormattingStatus FormattingStatus { get; set; }

        [Column("formatting_comment")]
        [MaxLength(10000)]
        public string FormattingComment { get; set; }

        [Column("delivery_status")]
        [MaxLength(40)]
        public DeliveryStatus DeliveryStatus { get; set; }

        [Column("delivery_comment")]
        [MaxLength(10000)]
        public string DeliveryComment { get; set; }

        [Column("message_group_id")]
        [MaxLength(100)]
        public string MessageGroupId { get; set; }
    }
}
