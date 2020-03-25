using System.Collections.Generic;

namespace Lykke.Service.NotificationSystemAudit.Client.Models
{
    /// <summary>
    /// Represents paged response with audit messages that have template parsing issues
    /// </summary>
    public class AuditMessageWithTemplateIssuesPaginatedResponseModel
    {
        /// <summary>
        /// The CurrentPage
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// The PageSize
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// The TotalCount of audit messages
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// List of AuditMessages for the given page
        /// </summary>
        public IEnumerable<AuditMessageWithTemplateIssuesResponseModel> AuditMessages { get; set; }
    }
}
