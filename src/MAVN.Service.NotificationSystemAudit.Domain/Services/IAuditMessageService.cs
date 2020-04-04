using System;
using System.Threading.Tasks;
using MAVN.Service.NotificationSystemAudit.Domain.Contracts;

namespace MAVN.Service.NotificationSystemAudit.Domain.Services
{
    public interface IAuditMessageService
    {
        Task<bool> CreateAsync(CreateAuditMessage message);

        Task<PaginatedAuditList> RetrievePaginatedMessagesAsync(int currentPage, int pageSize,
            DateTime? fromCreationTimestamp, DateTime? toCreationTimestamp, string messageType,
            string customerId, string deliveryStatus, string source, string messageGroupId, string messageId);

        Task<PaginatedAuditList> RetrieveDeliveryFailedMessagesAsync(int currentPage,
            int pageSize, DateTime? fromCreationTimestamp, DateTime? toCreationTimestamp, string messageType, string customerId,
            string source, string messageGroupId, string messageId);

        Task<bool> UpdateAsync(UpdateAuditMessage message);

        Task<PaginatedAuditList> GetPaginatedAuditMessagesWithParsingIssuesAsync(int currentPage, int pageSize,
            DateTime? fromCreationTimestamp, DateTime? toCreationTimestamp, string messageType, string customerId,
            string source, string messageGroupId, string messageId);
    }
}
