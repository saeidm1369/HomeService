using AutoMapper;
using HomeService.Domain.Core.PaymentAgg.DTOs;
using HomeService.Domain.Core.PaymentAgg.Entities;
using HomeService.Domain.Core.ServiceAgg.DTOs;
using HomeService.Domain.Core.ServiceAgg.Entities;
using HomeService.Domain.Core.UserAgg.DTOs;
using HomeService.Domain.Core.UserAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // UserAgg Mappings
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<ProfileImage, ProfileImageDTO>().ReverseMap();

            // ServiceAgg Mappings
            CreateMap<Service, ServiceDTO>().ReverseMap();
            CreateMap<ServiceCategory, ServiceCategoryDTO>().ReverseMap();
            CreateMap<ServiceImage, ServiceImageDTO>().ReverseMap();
            CreateMap<ServiceRequest, ServiceRequestDTO>().ReverseMap();
            CreateMap<ServiceRequestImage, ServiceRequestImageDTO>().ReverseMap();
            CreateMap<ServiceRequestStatus, ServiceRequestStatusDTO>().ReverseMap();
            CreateMap<ServiceSugesstion, ServiceSugesstionDTO>().ReverseMap();
            CreateMap<ExpertSkill, ExpertSkillDTO>().ReverseMap();
            CreateMap<Review, ReviewDTO>().ReverseMap();
            CreateMap<Skill, SkillDTO>().ReverseMap();

            // PaymentAgg Mappings
            CreateMap<Invoice, InvoiceDTO>().ReverseMap();
            CreateMap<InvoiceDetail, InvoiceDetailDTO>().ReverseMap();
            CreateMap<Payment, PaymentDTO>().ReverseMap();
            CreateMap<PaymentStatus, PaymentStatusDTO>().ReverseMap();
            
                                 

        }
    }
}
