using System;
using System.ComponentModel.DataAnnotations;

namespace MAVN.Service.NotificationSystemAudit.Client.Models
{
    /// <summary>
    /// Model used to request paginated data for audit messages that have template parsing issues
    /// </summary>
    public class AuditMessageWithTemplateIssuesPaginatedRequestModel
    {
        /// <summary>
        /// The current page
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int CurrentPage { get; set; }

        /// <summary>
        /// The page size
        /// </summary>
        [Required]
        [Range(10, 500)]
        public int PageSize { get; set; }

        /// <summary>
        /// Filter for FromCreationTimestamp
        /// </summary>
        public DateTime? FromCreationTimestamp { get; set; }

        /// <summary>
        /// Filter for ToCreationTimestamp
        /// </summary>
        public DateTime? ToCreationTimestamp { get; set; }

        /// <summary>
        /// Optional MessageType filter
        /// </summary>
        public string MessageType { get; set; }

        /// <summary>
        /// Optional CustomerId filter
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// The Source of this message
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Filter for message group id
        /// </summary>
        public string MessageGroupId { get; set; }

        /// <summary>
        /// Filter for message id
        /// </summary>
        public string MessageId { get; set; }
    }
}
