using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Lykke.Common.ApiLibrary.Exceptions;
using MAVN.Service.NotificationSystemAudit.Client;
using MAVN.Service.NotificationSystemAudit.Client.Models;
using MAVN.Service.NotificationSystemAudit.Domain.Enums;
using MAVN.Service.NotificationSystemAudit.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MAVN.Service.NotificationSystemAudit.Controllers
{
    [Route("/api/")]
    [ApiController]
    public class AuditMessageController : Controller, INotificationSystemAuditApi
    {
        private readonly IAuditMessageService _auditMessageService;
        private readonly IMapper _mapper;

        public AuditMessageController(IAuditMessageService auditMessageService, IMapper mapper)
        {
            _auditMessageService = auditMessageService;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        /// <response code="200">Success</response>
        [HttpPost("messages/all/")]
        [SwaggerOperation("Get audit messages (as paginated result)")]
        [ProducesResponseType(typeof(PaginatedAuditMessageResponseModel), (int) HttpStatusCode.OK)]
        public async Task<PaginatedAuditMessageResponseModel> RetrievePaginatedMessagesAsync(
            PaginatedAuditMessageRequestModel model)
        {
            if (!string.IsNullOrEmpty(model.DeliveryStatus) &&
                !Enum.TryParse(model.DeliveryStatus, true, out DeliveryStatus status))
            {
                throw new ValidationApiException(HttpStatusCode.BadRequest, "Invalid DeliveryStatus specified");
            }

            var paginatedSmsModel = await _auditMessageService.RetrievePaginatedMessagesAsync(model.CurrentPage,
                model.PageSize, model.FromCreationTimestamp, model.ToCreationTimestamp,
                model.MessageType, model.CustomerId, model.DeliveryStatus, model.Source, model.MessageGroupId,
                model.MessageId);

            return _mapper.Map<PaginatedAuditMessageResponseModel>(paginatedSmsModel);
        }

        /// <inheritdoc/>
        /// <response code="200">Success</response>
        [HttpPost("messages/templateParsingIssues/")]
        [SwaggerOperation("Get audit messages that have template parsing issues (as paginated result)")]
        [ProducesResponseType(typeof(PaginatedAuditMessageResponseModel), (int) HttpStatusCode.OK)]
        public async Task<PaginatedAuditMessageResponseModel> GetAuditMessagesWithTemplateParsingIssuesAsync(
            AuditMessageWithTemplateIssuesPaginatedRequestModel model)
        {
            var result =
                await _auditMessageService.GetPaginatedAuditMessagesWithParsingIssuesAsync(model.CurrentPage,
                    model.PageSize, model.FromCreationTimestamp, model.ToCreationTimestamp, model.MessageType, model.CustomerId,
                    model.Source, model.MessageGroupId, model.MessageId);

            return _mapper.Map<PaginatedAuditMessageResponseModel>(result);
        }

        /// <inheritdoc/>
        /// <response code="200">Success</response>
        [HttpPost("messages/failedDelivery/")]
        [SwaggerOperation("RetrieveDeliveryFailedMessagesAsync")]
        [ProducesResponseType(typeof(PaginatedAuditMessageResponseModel), (int) HttpStatusCode.OK)]
        public async Task<PaginatedDeliveryFailedAuditMessageResponseModel> RetrieveDeliveryFailedMessagesAsync(
            PaginatedDeliveryFailedAuditMessageRequestModel model)
        {
            var failedMessagesList = await _auditMessageService.RetrieveDeliveryFailedMessagesAsync(model.CurrentPage,
                model.PageSize, model.FromCreationTimestamp, model.ToCreationTimestamp, model.MessageType,
                model.CustomerId, model.Source, model.MessageGroupId, model.MessageId);

            return _mapper.Map<PaginatedDeliveryFailedAuditMessageResponseModel>(failedMessagesList);
        }
    }
}
