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
    public class ServiceImageAppService : IServiceImageAppService
    {
        private readonly IServiceImageRepository _serviceImageRepository;
        private readonly IMapper _mapper;

        public ServiceImageAppService(IServiceImageRepository serviceImageRepository, IMapper mapper)
        {
            _serviceImageRepository = serviceImageRepository;
            _mapper = mapper;
        }

        public async Task<ServiceImageDTO> GetServiceImageByIdAsync(int id)
        {
            var serviceImage = await _serviceImageRepository.GetByIdAsync(id);
            return _mapper.Map<ServiceImageDTO>(serviceImage);
        }

        public async Task<IEnumerable<ServiceImageDTO>> GetAllServiceImagesAsync()
        {
            var serviceImages = await _serviceImageRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ServiceImageDTO>>(serviceImages);
        }

        public async Task<ServiceImageDTO> CreateServiceImageAsync(ServiceImageDTO serviceImageDto)
        {
            var serviceImage = _mapper.Map<ServiceImage>(serviceImageDto);
            await _serviceImageRepository.AddAsync(serviceImage);
            return _mapper.Map<ServiceImageDTO>(serviceImage);
        }

        public async Task<ServiceImageDTO> UpdateServiceImageAsync(ServiceImageDTO serviceImageDto)
        {
            var serviceImage = await _serviceImageRepository.GetByIdAsync(serviceImageDto.Id);
            if (serviceImage == null)
            {
                return null;
            }

            _mapper.Map(serviceImageDto, serviceImage);
            await _serviceImageRepository.UpdateAsync(serviceImage);
            return _mapper.Map<ServiceImageDTO>(serviceImage);
        }

        public async Task<bool> DeleteServiceImageAsync(int id)
        {
            return await _serviceImageRepository.DeleteAsync(id);
        }
    }
}
