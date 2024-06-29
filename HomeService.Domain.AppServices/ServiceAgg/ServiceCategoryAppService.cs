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
    public class ServiceCategoryAppService : IServiceCategoryAppService
    {
        private readonly IServiceCategoryRepository _serviceCategoryRepository;
        private readonly IMapper _mapper;

        public ServiceCategoryAppService(IServiceCategoryRepository serviceCategoryRepository, IMapper mapper)
        {
            _serviceCategoryRepository = serviceCategoryRepository;
            _mapper = mapper;
        }

        public async Task<ServiceCategoryDTO> GetServiceCategoryByIdAsync(int id)
        {
            var serviceCategory = await _serviceCategoryRepository.GetByIdAsync(id);
            return _mapper.Map<ServiceCategoryDTO>(serviceCategory);
        }

        public async Task<IEnumerable<ServiceCategoryDTO>> GetAllServiceCategoriesAsync()
        {
            var serviceCategories = await _serviceCategoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ServiceCategoryDTO>>(serviceCategories);
        }

        public async Task<ServiceCategoryDTO> CreateServiceCategoryAsync(ServiceCategoryDTO serviceCategoryDto)
        {
            var serviceCategory = _mapper.Map<ServiceCategory>(serviceCategoryDto);
            await _serviceCategoryRepository.AddAsync(serviceCategory);
            return _mapper.Map<ServiceCategoryDTO>(serviceCategory);
        }

        public async Task<ServiceCategoryDTO> UpdateServiceCategoryAsync(ServiceCategoryDTO serviceCategoryDto)
        {
            var serviceCategory = await _serviceCategoryRepository.GetByIdAsync(serviceCategoryDto.Id);
            if (serviceCategory == null)
            {
                return null;
            }

            _mapper.Map(serviceCategoryDto, serviceCategory);
            await _serviceCategoryRepository.UpdateAsync(serviceCategory);
            return _mapper.Map<ServiceCategoryDTO>(serviceCategory);
        }

        public async Task<bool> DeleteServiceCategoryAsync(int id)
        {
            return await _serviceCategoryRepository.DeleteAsync(id);
        }
    }
}
