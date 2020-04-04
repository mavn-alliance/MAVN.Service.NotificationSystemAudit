using AutoMapper;
using MAVN.Service.NotificationSystemAudit.Client.Models;
using MAVN.Service.NotificationSystemAudit.Domain.Contracts;
using MAVN.Service.NotificationSystemAudit.Domain.Entities;

namespace MAVN.Service.NotificationSystemAudit.Profiles
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
