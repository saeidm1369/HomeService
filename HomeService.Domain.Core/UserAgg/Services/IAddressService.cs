using HomeService.Domain.Core.UserAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.UserAgg.Services
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressDTO>> GetAllAddressesAsync();
        Task<AddressDTO> GetAddressByIdAsync(int id);
        Task AddAddressAsync(AddressDTO addressDto);
        Task UpdateAddressAsync(AddressDTO addressDto);
        Task DeleteAddressAsync(int id);
    }
}
