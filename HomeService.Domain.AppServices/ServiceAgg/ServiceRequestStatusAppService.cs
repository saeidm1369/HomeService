using AutoMapper;
using HomeService.Domain.Core.ServiceAgg.AppServices;
using HomeService.Domain.Core.ServiceAgg.Data;
using HomeService.Domain.Core.ServiceAgg.DTOs;
using HomeService.Domain.Core.ServiceAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.AppServices.ServiceAgg
{
    public class ServiceRequestStatusAppService : IServiceRequestStatusAppService
    {
        private readonly IServiceRequestStatusRepository _serviceRequestStatusRepository;
        private readonly IMapper _mapper;

        public ServiceRequestStatusAppService(IServiceRequestStatusRepository serviceRequestStatusRepository, IMapper mapper)
        {
            _serviceRequestStatusRepository = serviceRequestStatusRepository;
            _mapper = mapper;
        }

        public async Task<ServiceRequestStatusDTO> GetServiceRequestStatusByIdAsync(int id)
        {
            var serviceRequestStatus = await _serviceRequestStatusRepository.GetByIdAsync(id);
            return _mapper.Map<ServiceRequestStatusDTO>(serviceRequestStatus);
        }

        public async Task<IEnumerable<ServiceRequestStatusDTO>> GetAllServiceRequestStatusesAsync()
        {
            var serviceRequestStatuses = await _serviceRequestStatusRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ServiceRequestStatusDTO>>(serviceRequestStatuses);
        }

        public async Task<ServiceRequestStatusDTO> CreateServiceRequestStatusAsync(ServiceRequestStatusDTO serviceRequestStatusDto)
        {
            var serviceRequestStatus = _mapper.Map<ServiceRequestStatus>(serviceRequestStatusDto);
            await _serviceRequestStatusRepository.AddAsync(serviceRequestStatus);
            return _mapper.Map<ServiceRequestStatusDTO>(serviceRequestStatus);
        }

        public async Task<ServiceRequestStatusDTO> UpdateServiceRequestStatusAsync(ServiceRequestStatusDTO serviceRequestStatusDto)
        {
            var serviceRequestStatus = await _serviceRequestStatusRepository.GetByIdAsync(serviceRequestStatusDto.Id);
            if (serviceRequestStatus == null)
            {
                return null;
            }

            _mapper.Map(serviceRequestStatusDto, serviceRequestStatus);
            await _serviceRequestStatusRepository.UpdateAsync(serviceRequestStatus);
            return _mapper.Map<ServiceRequestStatusDTO>(serviceRequestStatus);
        }

        public async Task<bool> DeleteServiceRequestStatusAsync(int id)
        {
            return await _serviceRequestStatusRepository.DeleteAsync(id);
        }
    }
}
