using System;
using System.ComponentModel.DataAnnotations;

namespace Lykke.Service.NotificationSystemAudit.Client.Models
{
    /// <summary>
    /// Model used for requesting data for failed audit messages 
    /// </summary>
    public class PaginatedDeliveryFailedAuditMessageRequestModel
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
        /// Filter for MessageType
        /// </summary>
        public string MessageType { get; set; }

        /// <summary>
        /// Filter for CustomerId
        /// </summary>
        public string CustomerId { get; set; }

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
