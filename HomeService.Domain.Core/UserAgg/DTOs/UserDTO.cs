using System;

namespace HomeService.Domain.Core.UserAgg.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string? FullName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public ProfileImageDTO? ProfileImage { get; set; }
        public AddressDTO? Address { get; set; }  
    }
}
