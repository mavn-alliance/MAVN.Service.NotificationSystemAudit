using System.Threading.Tasks;
using AutoMapper;
using Lykke.Common.Log;
using Lykke.Service.NotificationSystem.Contract.MessageContracts;
using MAVN.Service.NotificationSystemAudit.Domain.Contracts;
using MAVN.Service.NotificationSystemAudit.Domain.Services;

namespace MAVN.Service.NotificationSystemAudit.DomainServices.Subscribers
{
    public class CreateAuditMessageSubscriber : RabbitSubscriber<CreateAuditMessageEvent>
    {
        private const string CreateAuditMessageExchangeName = "lykke.notificationsystem.createauditmessage";

        private readonly IAuditMessageService _auditMessageService;
        private readonly IMapper _mapper;

        public CreateAuditMessageSubscriber(string connectionString,
            IAuditMessageService auditMessageService,
            ILogFactory logFactory,
            IMapper mapper) 
            : base(connectionString, CreateAuditMessageExchangeName, logFactory)
        {
            _auditMessageService = auditMessageService;
            _mapper = mapper;
        }

        protected override async Task ProcessMessageAsync(CreateAuditMessageEvent msg)
        {
            await _auditMessageService.CreateAsync(_mapper.Map<CreateAuditMessage>(msg));

            Log.Info($"Processed CreateAuditMessageEvent", msg);
        }
    }
}
