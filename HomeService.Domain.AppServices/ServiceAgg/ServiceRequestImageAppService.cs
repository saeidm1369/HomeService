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
    public class ServiceRequestImageAppService : IServiceRequestImageAppService
    {
        private readonly IServiceRequestImageRepository _serviceRequestImageRepository;
        private readonly IMapper _mapper;

        public ServiceRequestImageAppService(IServiceRequestImageRepository serviceRequestImageRepository, IMapper mapper)
        {
            _serviceRequestImageRepository = serviceRequestImageRepository;
            _mapper = mapper;
        }


        public async Task<ServiceRequestImageDTO> CreateServiceRequestImageAsync(ServiceRequestImageDTO serviceRequestImageDto)
        {
            var serviceRequestImage = _mapper.Map<ServiceRequestImage>(serviceRequestImageDto);
            await _serviceRequestImageRepository.AddAsync(serviceRequestImage);
            return _mapper.Map<ServiceRequestImageDTO>(serviceRequestImage);
        }

        public async Task<bool> DeleteServiceRequestImageAsync(int id)
        {
            return await _serviceRequestImageRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ServiceRequestImageDTO>> GetAllServiceRequestImagesAsync()
        {
            var serviceRequestImages = await _serviceRequestImageRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ServiceRequestImageDTO>>(serviceRequestImages);
        }

        public async Task<ServiceRequestImageDTO> GetServiceRequestImageByIdAsync(int id)
        {
            var serviceRequestImage = await _serviceRequestImageRepository.GetByIdAsync(id);
            return _mapper.Map<ServiceRequestImageDTO>(serviceRequestImage);
        }

        public async Task<ServiceRequestImageDTO> UpdateServiceRequestImageAsync(ServiceRequestImageDTO serviceRequestImageDto)
        {
            var serviceRequestImage = _mapper.Map<ServiceRequestImage>(serviceRequestImageDto);
            await _serviceRequestImageRepository.UpdateAsync(serviceRequestImage);
            return _mapper.Map<ServiceRequestImageDTO>(serviceRequestImage);

        }
    }
}
