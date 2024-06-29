using AutoMapper;
using HomeService.Domain.Core.ServiceAgg.Data;
using HomeService.Domain.Core.ServiceAgg.DTOs;
using HomeService.Domain.Core.ServiceAgg.Entities;
using HomeService.Domain.Core.ServiceAgg.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Services.ServiceAgg
{
    public class ServiceCategoryService : IServiceCategoryService
    {
        private readonly IServiceCategoryRepository _serviceCategoryRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly ILogger<ServiceCategoryService> _logger;

        public ServiceCategoryService(IServiceCategoryRepository serviceCategoryRepository, IMapper mapper, IMemoryCache cache, ILogger<ServiceCategoryService> logger)
        {
            _serviceCategoryRepository = serviceCategoryRepository;
            _mapper = mapper;
            _cache = cache;
            _logger = logger;
        }

        public async Task<ServiceCategoryDTO> GetServiceCategoryByIdAsync(int id)
        {
            var serviceCategory = await _serviceCategoryRepository.GetByIdAsync(id);
            if (serviceCategory == null)
            {
                _logger.LogWarning("ServiceCategory not found: {Id}", id);
                throw new KeyNotFoundException("ServiceCategory not found.");
            }

            _logger.LogInformation("Retrieved ServiceCategory by id: {Id}", id);
            return _mapper.Map<ServiceCategoryDTO>(serviceCategory);
        }

        public async Task<IEnumerable<ServiceCategoryDTO>> GetAllServiceCategoriesAsync()
        {
            if (!_cache.TryGetValue("AllServiceCategories", out IEnumerable<ServiceCategoryDTO> cachedServiceCategories))
            {
                var serviceCategories = await _serviceCategoryRepository.GetAllAsync();
                cachedServiceCategories = _mapper.Map<IEnumerable<ServiceCategoryDTO>>(serviceCategories);
                _cache.Set("AllServiceCategories", cachedServiceCategories);
            }

            _logger.LogInformation("Retrieved all ServiceCategories from cache");
            return cachedServiceCategories;
        }

        public async Task<ServiceCategoryDTO> CreateServiceCategoryAsync(ServiceCategoryDTO serviceCategoryDto)
        {
            var serviceCategory = _mapper.Map<ServiceCategory>(serviceCategoryDto);
            await _serviceCategoryRepository.AddAsync(serviceCategory);
            _logger.LogInformation("ServiceCategory created: {@ServiceCategory}", serviceCategory);
            _cache.Remove("AllServiceCategories");
            return _mapper.Map<ServiceCategoryDTO>(serviceCategory);
        }

        public async Task<ServiceCategoryDTO> UpdateServiceCategoryAsync(ServiceCategoryDTO serviceCategoryDto)
        {
            var serviceCategory = _mapper.Map<ServiceCategory>(serviceCategoryDto);
            await _serviceCategoryRepository.UpdateAsync(serviceCategory);
            _logger.LogInformation("ServiceCategory updated: {@ServiceCategory}", serviceCategory);
            _cache.Remove("AllServiceCategories");
            return _mapper.Map<ServiceCategoryDTO>(serviceCategory);
        }

        public async Task<bool> DeleteServiceCategoryAsync(int id)
        {
            var result = await _serviceCategoryRepository.DeleteAsync(id);
            _logger.LogInformation("ServiceCategory deleted: {Id}", id);
            _cache.Remove("AllServiceCategories");
            return result;
        }
    }

   
}

