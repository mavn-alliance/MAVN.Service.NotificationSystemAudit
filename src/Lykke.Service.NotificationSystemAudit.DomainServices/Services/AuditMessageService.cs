using System;
using System.Threading.Tasks;
using Lykke.Service.NotificationSystemAudit.Domain.Contracts;
using Lykke.Service.NotificationSystemAudit.Domain.Repositories;
using Lykke.Service.NotificationSystemAudit.Domain.Services;

namespace Lykke.Service.NotificationSystemAudit.DomainServices.Services
{
    public class AuditMessageService : IAuditMessageService
    {
        private readonly IAuditMessageRepository _auditMessageRepository;

        public AuditMessageService(IAuditMessageRepository auditMessageRepository)
        {
            _auditMessageRepository = auditMessageRepository;
        }

        public Task<bool> CreateAsync(CreateAuditMessage message)
        {
            return _auditMessageRepository.CreateAsync(message);
        }

        public async Task<PaginatedAuditList> RetrievePaginatedMessagesAsync(int currentPage, int pageSize,
            DateTime? fromCreationTimestamp, DateTime? toCreationTimestamp, string messageType, string customerId,
            string deliveryStatus, string source, string messageGroupId, string messageId)
        {
            if (currentPage < 1)
                throw new ArgumentException("Current page can't be negative or zero", nameof(currentPage));

            if (pageSize < 10)
            {
                throw new ArgumentException("Page size can't be bellow 10", nameof(pageSize));
            }

            if (pageSize > 500)
            {
                throw new ArgumentException("Page size can't be above 500", nameof(pageSize));
            }

            var skip = (currentPage - 1) * pageSize;
            var take = pageSize;

            var paginatedSmsModel = await _auditMessageRepository.RetrievePaginatedMessagesAsync(skip, take,
                fromCreationTimestamp, toCreationTimestamp, messageType, customerId, deliveryStatus, source,
                messageGroupId, messageId);

            paginatedSmsModel.CurrentPage = currentPage;
            paginatedSmsModel.PageSize = pageSize;

            return paginatedSmsModel;
        }

        public Task<PaginatedAuditList> RetrieveDeliveryFailedMessagesAsync(int currentPage, int pageSize,
            DateTime? fromCreationTimestamp, DateTime? toCreationTimestamp, string messageType,
            string customerId, string source, string messageGroupId, string messageId)
        {
            if (currentPage < 1)
                throw new ArgumentException("Current page can't be negative or zero", nameof(currentPage));

            if (pageSize < 10)
            {
                throw new ArgumentException("Page size can't be bellow 10", nameof(pageSize));
            }

            if (pageSize > 500)
            {
                throw new ArgumentException("Page size can't be above 500", nameof(pageSize));
            }

            var skip = (currentPage - 1) * pageSize;
            var take = pageSize;

            return _auditMessageRepository.RetrieveDeliveryFailedMessagesAsync(skip, take, fromCreationTimestamp,
                toCreationTimestamp, messageType, customerId, source, messageGroupId, messageId);
        }

        public Task<bool> UpdateAsync(UpdateAuditMessage message)
        {
            return _auditMessageRepository.UpdateAsync(message);
        }

        public async Task<PaginatedAuditList> GetPaginatedAuditMessagesWithParsingIssuesAsync(int currentPage,
            int pageSize, DateTime? fromCreationTimestamp, DateTime? toCreationTimestamp, string messageType,
            string customerId,
            string source, string messageGroupId, string messageId)
        {
            if (currentPage < 1)
                throw new ArgumentException("Current page can't be negative or zero", nameof(currentPage));

            if (pageSize < 10)
            {
                throw new ArgumentException("Page size can't be bellow 10", nameof(pageSize));
            }

            if (pageSize > 500)
            {
                throw new ArgumentException("Page size can't be above 500", nameof(pageSize));
            }

            var skip = (currentPage - 1) * pageSize;
            var take = pageSize;

            var result =
                await _auditMessageRepository.GetPaginatedMessagesWithParsingIssuesAsync(skip, take,
                    fromCreationTimestamp, toCreationTimestamp, messageType, customerId, source, messageGroupId,
                    messageId);

            result.CurrentPage = currentPage;
            result.PageSize = pageSize;

            return result;
        }
    }
}
