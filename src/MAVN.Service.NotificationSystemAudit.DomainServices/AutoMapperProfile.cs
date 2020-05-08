using AutoMapper;
using JetBrains.Annotations;
using MAVN.Service.NotificationSystem.Contract.MessageContracts;
using MAVN.Service.NotificationSystemAudit.Domain.Contracts;
using MAVN.Service.NotificationSystemBroker.Contract;
using MAVN.Service.NotificationSystemBroker.Contract.Enums;

namespace MAVN.Service.NotificationSystemAudit.DomainServices
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
