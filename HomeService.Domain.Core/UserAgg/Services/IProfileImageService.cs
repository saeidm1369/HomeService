using HomeService.Domain.Core.UserAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.UserAgg.Services
{
    public interface IProfileImageService
    {
        Task<ProfileImageDTO> GetProfileImageByIdAsync(int id);
        Task<IEnumerable<ProfileImageDTO>> GetAllProfileImagesAsync();
        Task<ProfileImageDTO> CreateProfileImageAsync(ProfileImageDTO profileImageDto);
        Task<ProfileImageDTO> UpdateProfileImageAsync(ProfileImageDTO profileImageDto);
        Task<bool> DeleteProfileImageAsync(int id);
    }
}
