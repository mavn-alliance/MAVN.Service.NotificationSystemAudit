using System.Collections.Generic;
using Lykke.Service.NotificationSystemAudit.Domain.Entities;

namespace Lykke.Service.NotificationSystemAudit.Domain.Contracts
{
    public class PaginatedAuditList
    {
        public IEnumerable<IAuditMessage> AuditMessages { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }
    }
}
