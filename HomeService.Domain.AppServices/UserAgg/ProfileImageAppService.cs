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
    public class ProfileImageAppService : IProfileImageAppService
    {
        private readonly IProfileImageRepository _profileImageRepository;
        private readonly IMapper _mapper;

        public ProfileImageAppService(IProfileImageRepository profileImageRepository, IMapper mapper)
        {
            _profileImageRepository = profileImageRepository;
            _mapper = mapper;
        }

        public async Task<ProfileImageDTO> GetProfileImageByIdAsync(int id)
        {
            var profileImage = await _profileImageRepository.GetByIdAsync(id);
            return _mapper.Map<ProfileImageDTO>(profileImage);
        }

        public async Task<IEnumerable<ProfileImageDTO>> GetAllProfileImagesAsync()
        {
            var profileImages = await _profileImageRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProfileImageDTO>>(profileImages);
        }

        public async Task<ProfileImageDTO> CreateProfileImageAsync(ProfileImageDTO profileImageDto)
        {
            var profileImage = _mapper.Map<ProfileImage>(profileImageDto);
            await _profileImageRepository.AddAsync(profileImage);
            return _mapper.Map<ProfileImageDTO>(profileImage);
        }

        public async Task<ProfileImageDTO> UpdateProfileImageAsync(ProfileImageDTO profileImageDto)
        {
            var profileImage = await _profileImageRepository.GetByIdAsync(profileImageDto.Id);
            if (profileImage == null)
            {
                return null;
            }

            _mapper.Map(profileImageDto, profileImage);
            await _profileImageRepository.UpdateAsync(profileImage);
            return _mapper.Map<ProfileImageDTO>(profileImage);
        }

        public async Task<bool> DeleteProfileImageAsync(int id)
        {
            return await _profileImageRepository.DeleteAsync(id);
        }
    }
}
