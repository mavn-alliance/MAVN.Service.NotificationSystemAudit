using System.Threading.Tasks;
using AutoMapper;
using Lykke.Common.Log;
using Lykke.Service.NotificationSystemAudit.Domain.Contracts;
using Lykke.Service.NotificationSystemAudit.Domain.Services;
using Lykke.Service.NotificationSystemBroker.Contract;

namespace Lykke.Service.NotificationSystemAudit.DomainServices.Subscribers
{
    public class UpdateAuditMessageSubscriber : RabbitSubscriber<UpdateAuditMessageEvent>
    {
        private const string UpdateAuditMessageExchangeName = "lykke.notificationsystem.updateauditmessage";

        private readonly IAuditMessageService _auditMessageService;
        private readonly IMapper _mapper;

        public UpdateAuditMessageSubscriber(string connectionString,
            IAuditMessageService auditMessageService,
            ILogFactory logFactory,
            IMapper mapper) 
            : base(connectionString, UpdateAuditMessageExchangeName, logFactory)
        {
            _auditMessageService = auditMessageService;
            _mapper = mapper;
        }

        protected override async Task ProcessMessageAsync(UpdateAuditMessageEvent msg)
        {
            await _auditMessageService.UpdateAsync(_mapper.Map<UpdateAuditMessage>(msg));

            Log.Info($"Processed UpdateAuditMessageEvent", msg);
        }
    }
}
