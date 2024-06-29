using AutoMapper;
using HomeService.Domain.Core.UserAgg.Data;
using HomeService.Domain.Core.UserAgg.DTOs;
using HomeService.Domain.Core.UserAgg.Entities;
using HomeService.Domain.Core.UserAgg.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Services.UserAgg
{
    public class AddressService : IAddressService
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;
        private readonly IMemoryCache _cache;
        private readonly ILogger<AddressService> _logger;

        public AddressService(IMapper mapper, IAddressRepository addressRepository, IMemoryCache cache, ILogger<AddressService> logger)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
            _cache = cache;
            _logger = logger;
        }

        public async Task<IEnumerable<AddressDTO>> GetAllAddressesAsync()
        {
            const string cacheKey = "AllAddresses";
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<AddressDTO> cachedAddresses))
            {
                var addresses = await _addressRepository.GetAllAsync();
                cachedAddresses = _mapper.Map<IEnumerable<AddressDTO>>(addresses);
                _cache.Set(cacheKey, cachedAddresses);
            }

            _logger.LogInformation("Retrieved all addresses from cache");
            return cachedAddresses;
        }

        public async Task<AddressDTO> GetAddressByIdAsync(int id)
        {
            var cacheKey = $"Address_{id}";
            if (!_cache.TryGetValue(cacheKey, out AddressDTO addressDto))
            {
                var address = await _addressRepository.GetByIdAsync(id);
                addressDto = _mapper.Map<AddressDTO>(address);
                _cache.Set(cacheKey, addressDto);
            }

            _logger.LogInformation("Retrieved address by id: {Id}", id);
            return addressDto;
        }

        public async Task AddAddressAsync(AddressDTO addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            await _addressRepository.AddAsync(address);
            _logger.LogInformation("Address added: {@Address}", address);
            _cache.Remove("AllAddresses");
        }

        public async Task UpdateAddressAsync(AddressDTO addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            await _addressRepository.UpdateAsync(address);
            _logger.LogInformation("Address updated: {@Address}", address);
            _cache.Remove("AllAddresses");
            _cache.Remove($"Address_{address.Id}");
        }

        public async Task DeleteAddressAsync(int id)
        {
            await _addressRepository.DeleteAsync(id);
            _logger.LogInformation("Address deleted: {Id}", id);
            _cache.Remove("AllAddresses");
            _cache.Remove($"Address_{id}");
        }
    }
}
