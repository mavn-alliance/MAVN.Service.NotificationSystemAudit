using AutoMapper;
using JetBrains.Annotations;
using Lykke.Service.NotificationSystem.Contract.MessageContracts;
using Lykke.Service.NotificationSystemAudit.Domain.Contracts;
using Lykke.Service.NotificationSystemBroker.Contract;
using Lykke.Service.NotificationSystemBroker.Contract.Enums;

namespace Lykke.Service.NotificationSystemAudit.DomainServices
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DeliveryStatus, Domain.Enums.DeliveryStatus>()
                .ConvertUsing(value =>
                    value == DeliveryStatus.Error
                        ? Domain.Enums.DeliveryStatus.Failed
                        : value == DeliveryStatus.Ok
                            ? Domain.Enums.DeliveryStatus.Success
                            : Domain.Enums.DeliveryStatus.Pending);

            CreateMap<UpdateAuditMessageEvent, UpdateAuditMessage>();
            CreateMap<CreateAuditMessageEvent, CreateAuditMessage>();
        }
    }
}
