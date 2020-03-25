using AutoMapper;
using Lykke.Service.NotificationSystemAudit.Client.Models;
using Lykke.Service.NotificationSystemAudit.Domain.Contracts;
using Lykke.Service.NotificationSystemAudit.Domain.Entities;

namespace Lykke.Service.NotificationSystemAudit.Profiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<IAuditMessage, AuditMessageResponseModel>();
            CreateMap<PaginatedAuditList, PaginatedAuditMessageResponseModel>();
            CreateMap<IAuditMessage, DeliveryFailedAuditMessageResponseModel>();
            CreateMap<PaginatedAuditList, PaginatedDeliveryFailedAuditMessageResponseModel>();
            CreateMap<DeliveryFailedAuditMessageContract, DeliveryFailedAuditMessageResponseModel>()
                .ForMember(x => x.CallType, 
                    opt => opt.MapFrom(src => src.CallType.ToString()));
        }

    }
}
