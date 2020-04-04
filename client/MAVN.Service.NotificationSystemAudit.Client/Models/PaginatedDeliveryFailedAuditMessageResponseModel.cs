using System.Collections.Generic;

namespace MAVN.Service.NotificationSystemAudit.Client.Models
{
    /// <summary>
    /// Paged list of all audit messages that are failed
    /// </summary>
    public class PaginatedDeliveryFailedAuditMessageResponseModel
    {
        /// <summary>
        /// List of AuditMessages for the given page
        /// </summary>
        public IEnumerable<DeliveryFailedAuditMessageResponseModel> AuditMessages { get; set; }

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
