using System.Threading.Tasks;
using JetBrains.Annotations;
using Lykke.Service.NotificationSystemAudit.Client.Models;
using Refit;

namespace Lykke.Service.NotificationSystemAudit.Client
{
    /// <summary>
    /// NotificationSystemAudit client API interface.
    /// </summary>
    [PublicAPI]
    public interface INotificationSystemAuditApi
    {
        /// <summary>
        /// Retrieves paged audit messages with options for filtering
        /// </summary>
        /// <param name="model">Model containing info on how to page and filter the requested data</param>
        /// <returns>Paginated list of audit messages</returns>
        [Post("api/messages/all/")]
        Task<PaginatedAuditMessageResponseModel>
            RetrievePaginatedMessagesAsync(PaginatedAuditMessageRequestModel model);

        /// <summary>
        /// Retrieves paged audit messages that have template parsing issues
        /// </summary>
        /// <param name="model">Model containing info on how to page and filter the requested data</param>
        /// <returns>Paginated list of audit messages</returns>
        [Post("api/messages/templateParsingIssues/")]
        Task<PaginatedAuditMessageResponseModel> GetAuditMessagesWithTemplateParsingIssuesAsync(
            AuditMessageWithTemplateIssuesPaginatedRequestModel model);

        /// <summary>
        /// Retrieves failed audit messages with options for filtering
        /// </summary>
        /// <param name="model">Model containing info on how filter the requested data</param>
        /// <returns>Paginated list of audit messages</returns>
        [Post("api/messages/failedDelivery/")]
        Task<PaginatedDeliveryFailedAuditMessageResponseModel> RetrieveDeliveryFailedMessagesAsync(PaginatedDeliveryFailedAuditMessageRequestModel model);
    }
}
