using System.Collections.Generic;

namespace MAVN.Service.NotificationSystemAudit.Client.Models
{
    /// <summary>
    /// Gives the List of AuditMessages on the desired Page and information about the Page
    /// </summary>
    public class PaginatedAuditMessageResponseModel
    {
        /// <summary>
        /// List of AuditMessages for the given page
        /// </summary>
        public IEnumerable<AuditMessageResponseModel> AuditMessages { get; set; }

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
    }
}
