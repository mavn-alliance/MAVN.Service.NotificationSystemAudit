using System;
using System.Threading.Tasks;
using MAVN.Service.NotificationSystemAudit.Domain.Contracts;

namespace MAVN.Service.NotificationSystemAudit.Domain.Repositories
{
    public interface IAuditMessageRepository
    {
        Task<bool> CreateAsync(CreateAuditMessage message);

        Task<PaginatedAuditList> RetrievePaginatedMessagesAsync(int skip, int take,
            DateTime? fromCreationTimestamp, DateTime? toCreationTimestamp, string messageType,
            string customerId, string deliveryStatus, string source, string messageGroupId, string messageId);

        Task<PaginatedAuditList> RetrieveDeliveryFailedMessagesAsync(int skip, int take,
            DateTime? fromCreationTimestamp, DateTime? toCreationTimestamp, string messageType, string customerId,
            string source, string messageGroupId, string messageId);

        Task<bool> UpdateAsync(UpdateAuditMessage message);

        Task<PaginatedAuditList> GetPaginatedMessagesWithParsingIssuesAsync(int skip, int take,
            DateTime? fromCreationTimestamp, DateTime? toCreationTimestamp, string messageType, string customerId,
            string source, string messageGroupId, string messageId);
    }
}
