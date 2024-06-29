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
    public class ServiceRequestAppService : IServiceRequestAppService
    {
        private readonly IMapper _mapper;
        private readonly IServiceRequestRepository _serviceRequestRepository;

        public ServiceRequestAppService(IMapper mapper, IServiceRequestRepository serviceRequestRepository)
        {
            _mapper = mapper;
            _serviceRequestRepository = serviceRequestRepository;
        }

        public async Task<IEnumerable<ServiceRequestDTO>> GetAllServiceRequestsAsync()
        {
            var serviceRequests = await _serviceRequestRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ServiceRequestDTO>>(serviceRequests);
        }

        public async Task<ServiceRequestDTO> GetServiceRequestByIdAsync(int id)
        {
            var serviceRequest = await _serviceRequestRepository.GetByIdAsync(id);
            return _mapper.Map<ServiceRequestDTO>(serviceRequest);
        }

        public async Task AddServiceRequestAsync(ServiceRequestDTO serviceRequestDto)
        {
            var serviceRequest = _mapper.Map<ServiceRequest>(serviceRequestDto);
            await _serviceRequestRepository.AddAsync(serviceRequest);
        }

        public async Task UpdateServiceRequestAsync(ServiceRequestDTO serviceRequestDto)
        {
            var serviceRequest = _mapper.Map<ServiceRequest>(serviceRequestDto);
            await _serviceRequestRepository.UpdateAsync(serviceRequest);
        }

        public async Task DeleteServiceRequestAsync(int id)
        {
            await _serviceRequestRepository.DeleteAsync(id);
        }
    }
}
