using System.Collections.Generic;
using MAVN.Service.NotificationSystemAudit.Domain.Entities;

namespace MAVN.Service.NotificationSystemAudit.Domain.Contracts
{
    public class PaginatedAuditList
    {
        public IEnumerable<IAuditMessage> AuditMessages { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }
    }
}
