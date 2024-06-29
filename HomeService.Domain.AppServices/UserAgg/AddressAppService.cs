using AutoMapper;
using HomeService.Domain.Core.UserAgg.AppServices;
using HomeService.Domain.Core.UserAgg.Data;
using HomeService.Domain.Core.UserAgg.DTOs;
using HomeService.Domain.Core.UserAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.AppServices.UserAgg
{
    public class AddressAppService : IAddressAppService
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;

        public AddressAppService(IMapper mapper, IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public async Task<IEnumerable<AddressDTO>> GetAllAddressesAsync()
        {
            var addresses = await _addressRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AddressDTO>>(addresses);
        }

        public async Task<AddressDTO> GetAddressByIdAsync(int id)
        {
            var address = await _addressRepository.GetByIdAsync(id);
            return _mapper.Map<AddressDTO>(address);
        }

        public async Task AddAddressAsync(AddressDTO addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            await _addressRepository.AddAsync(address);
        }

        public async Task UpdateAddressAsync(AddressDTO addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            await _addressRepository.UpdateAsync(address);
        }

        public async Task DeleteAddressAsync(int id)
        {
            await _addressRepository.DeleteAsync(id);
        }
    }
}
