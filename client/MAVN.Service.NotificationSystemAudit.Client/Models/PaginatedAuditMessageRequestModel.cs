using System;
using System.ComponentModel.DataAnnotations;

namespace MAVN.Service.NotificationSystemAudit.Client.Models
{
    /// <summary>
    /// Model used for requesting paginated data for audit messages
    /// </summary>
    public class PaginatedAuditMessageRequestModel
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
        /// Optional DeliveryStatus filter
        /// </summary>
        public string DeliveryStatus { get; set; }

        /// <summary>
        /// Filter for Source
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
