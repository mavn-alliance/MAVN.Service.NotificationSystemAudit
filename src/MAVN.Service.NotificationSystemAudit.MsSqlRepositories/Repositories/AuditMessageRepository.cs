using System;
using System.Linq;
using System.Threading.Tasks;
using Common.Log;
using Lykke.Common.Log;
using MAVN.Common.MsSql;
using MAVN.Service.NotificationSystemAudit.Domain.Contracts;
using MAVN.Service.NotificationSystemAudit.Domain.Enums;
using MAVN.Service.NotificationSystemAudit.Domain.Repositories;
using MAVN.Service.NotificationSystemAudit.MsSqlRepositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace MAVN.Service.NotificationSystemAudit.MsSqlRepositories.Repositories
{
    public class AuditMessageRepository : IAuditMessageRepository
    {
        private readonly MsSqlContextFactory<AuditMessageContext> _contextFactory;
        private readonly ILog _log;

        public AuditMessageRepository(MsSqlContextFactory<AuditMessageContext> contextFactory,
            ILogFactory logFactory)
        {
            _contextFactory = contextFactory;
            _log = logFactory.CreateLog(this);
        }

        public async Task<bool> CreateAsync(CreateAuditMessage message)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                try
                {
                    var entity = new AuditMessage
                    {
                        CreationTimestamp = message.Timestamp,
                        MessageId = message.MessageId,
                        MessageType = message.MessageType,
                        CustomerId = message.CustomerId,
                        SubjectTemplateId = message.SubjectTemplateId,
                        MessageTemplateId = message.MessageTemplateId,
                        Source = message.Source,
                        CallType = message.CallType,
                        FormattingStatus = message.FormattingStatus,
                        FormattingComment = message.FormattingComment,
                        DeliveryStatus = DeliveryStatus.Pending
                    };

                    context.AuditMessages.Add(entity);

                    await context.SaveChangesAsync();

                    return true;
                }
                catch (DbUpdateException e)
                {
                    _log.Warning("Error creating audit message entry", e);
                    return false;
                }
            }
        }

        public async Task<PaginatedAuditList> RetrievePaginatedMessagesAsync(int skip, int take,
            DateTime? fromCreationTimestamp, DateTime? toCreationTimestamp, string messageType,
            string customerId, string deliveryStatus, string source, string messageGroupId, string messageId)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var query = context.AuditMessages.AsQueryable();

                if (!string.IsNullOrWhiteSpace(messageType))
                {
                    query = query.Where(am => am.MessageType == messageType);
                }

                if (!string.IsNullOrWhiteSpace(customerId))
                {
                    query = query.Where(am => am.CustomerId == customerId);
                }

                if (fromCreationTimestamp.HasValue)
                {
                    query = query.Where(am => am.CreationTimestamp >= fromCreationTimestamp.Value);
                }

                if (toCreationTimestamp.HasValue)
                {
                    query = query.Where(am => am.CreationTimestamp <= toCreationTimestamp.Value);
                }

                if (!string.IsNullOrWhiteSpace(deliveryStatus) &&
                    Enum.TryParse(deliveryStatus, true, out DeliveryStatus status))
                {
                    query = query.Where(am => am.DeliveryStatus == status);
                }

                if (!string.IsNullOrWhiteSpace(source))
                {
                    query = query.Where(am => am.Source == source);
                }

                if (!string.IsNullOrEmpty(messageGroupId))
                {
                    query = query.Where(am => am.MessageGroupId == messageGroupId);
                }

                if (!string.IsNullOrEmpty(messageId))
                {
                    query = query.Where(am => am.MessageId == messageId);
                }

                var result = await query
                    .OrderByDescending(sms => sms.CreationTimestamp)
                    .Skip(skip)
                    .Take(take)
                    .ToArrayAsync();

                var totalCount = await query.CountAsync();

                return new PaginatedAuditList {AuditMessages = result, TotalCount = totalCount};
            }
        }

        public async Task<PaginatedAuditList> RetrieveDeliveryFailedMessagesAsync(int skip,
            int take, DateTime? fromCreationTimestamp, DateTime? toCreationTimestamp, string messageType,
            string customerId, string source, string messageGroupId, string messageId)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var auditMessageQuery = context.AuditMessages.Where(am => am.DeliveryStatus == DeliveryStatus.Failed);

                if (fromCreationTimestamp.HasValue)
                {
                    auditMessageQuery =
                        auditMessageQuery.Where(am => am.CreationTimestamp >= fromCreationTimestamp.Value);
                }

                if (toCreationTimestamp.HasValue)
                {
                    auditMessageQuery =
                        auditMessageQuery.Where(am => am.CreationTimestamp <= toCreationTimestamp.Value);
                }

                if (!string.IsNullOrWhiteSpace(messageType))
                {
                    auditMessageQuery = auditMessageQuery.Where(am => am.MessageType == messageType);
                }

                if (!string.IsNullOrWhiteSpace(customerId))
                {
                    auditMessageQuery = auditMessageQuery.Where(am => am.CustomerId == customerId);
                }

                if (!string.IsNullOrWhiteSpace(source))
                {
                    auditMessageQuery = auditMessageQuery.Where(am => am.Source == source);
                }

                if (!string.IsNullOrEmpty(messageGroupId))
                {
                    auditMessageQuery = auditMessageQuery.Where(am => am.MessageGroupId == messageGroupId);
                }

                if (!string.IsNullOrEmpty(messageId))
                {
                    auditMessageQuery = auditMessageQuery.Where(am => am.MessageId == messageId);
                }

                var result = await auditMessageQuery
                    .OrderByDescending(sms => sms.CreationTimestamp)
                    .Skip(skip)
                    .Take(take)
                    .ToArrayAsync();

                var totalCount = await auditMessageQuery.CountAsync();

                return new PaginatedAuditList {AuditMessages = result, TotalCount = totalCount};
            }
        }


        public async Task<bool> UpdateAsync(UpdateAuditMessage message)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var entity = await context.AuditMessages.FirstOrDefaultAsync(sms =>
                    sms.MessageId == message.MessageId);

                if (entity == null)
                    return false;

                entity.SentTimestamp = message.SentTimestamp;
                entity.DeliveryStatus = message.DeliveryStatus;
                entity.DeliveryComment = message.DeliveryComment;

                context.Update(entity);

                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<PaginatedAuditList> GetPaginatedMessagesWithParsingIssuesAsync(int skip, int take,
            DateTime? fromCreationTimestamp, DateTime? toCreationTimestamp, string messageType, string customerId,
            string source, string messageGroupId, string messageId)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var query = context.AuditMessages.AsQueryable();

                // Get messages that have parsing issues
                query = query.Where(x => x.FormattingStatus == FormattingStatus.ValueNotFound);

                // Filter
                if (fromCreationTimestamp.HasValue)
                {
                    query = query.Where(am => am.CreationTimestamp >= fromCreationTimestamp.Value);
                }

                if (toCreationTimestamp.HasValue)
                {
                    query = query.Where(am => am.CreationTimestamp <= toCreationTimestamp.Value);
                }

                if (!string.IsNullOrWhiteSpace(messageType))
                {
                    query = query.Where(am => am.MessageType == messageType);
                }

                if (!string.IsNullOrWhiteSpace(customerId))
                {
                    query = query.Where(am => am.CustomerId == customerId);
                }

                if (!string.IsNullOrWhiteSpace(source))
                {
                    query = query.Where(am => am.Source == source);
                }

                if (!string.IsNullOrEmpty(messageGroupId))
                {
                    query = query.Where(am => am.MessageGroupId == messageGroupId);
                }

                if (!string.IsNullOrEmpty(messageId))
                {
                    query = query.Where(am => am.MessageId == messageId);
                }

                // Order and take exact number of records from specific page
                var result = await query
                    .OrderByDescending(sms => sms.CreationTimestamp)
                    .Skip(skip)
                    .Take(take)
                    .ToArrayAsync();

                var totalCount = await query.CountAsync();

                return new PaginatedAuditList {AuditMessages = result, TotalCount = totalCount};
            }
        }
    }
}
