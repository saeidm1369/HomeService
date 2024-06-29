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
    public class ServiceSugesstionAppService : IServiceSugesstionAppService
    {
        private readonly IMapper _mapper;
        private readonly IServiceSugesstionRepository _ServiceSugesstionRepository;

        public ServiceSugesstionAppService(IMapper mapper, IServiceSugesstionRepository ServiceSugesstionRepository)
        {
            _mapper = mapper;
            _ServiceSugesstionRepository = ServiceSugesstionRepository;
        }

        public async Task<IEnumerable<ServiceSugesstionDTO>> GetAllServiceSugesstionsAsync()
        {
            var ServiceSugesstions = await _ServiceSugesstionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ServiceSugesstionDTO>>(ServiceSugesstions);
        }

        public async Task<ServiceSugesstionDTO> GetServiceSugesstionByIdAsync(int id)
        {
            var ServiceSugesstion = await _ServiceSugesstionRepository.GetByIdAsync(id);
            return _mapper.Map<ServiceSugesstionDTO>(ServiceSugesstion);
        }

        public async Task AddServiceSugesstionAsync(ServiceSugesstionDTO ServiceSugesstionDto)
        {
            var ServiceSugesstion = _mapper.Map<ServiceSugesstion>(ServiceSugesstionDto);
            await _ServiceSugesstionRepository.AddAsync(ServiceSugesstion);
        }

        public async Task UpdateServiceSugesstionAsync(ServiceSugesstionDTO ServiceSugesstionDto)
        {
            var ServiceSugesstion = _mapper.Map<ServiceSugesstion>(ServiceSugesstionDto);
            await _ServiceSugesstionRepository.UpdateAsync(ServiceSugesstion);
        }

        public async Task DeleteServiceSugesstionAsync(int id)
        {
            await _ServiceSugesstionRepository.DeleteAsync(id);
        }
    }
}
