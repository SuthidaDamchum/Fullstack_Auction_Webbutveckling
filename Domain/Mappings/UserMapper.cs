using Domain.Entities;
using Domain.DTOs;
namespace Domain.Mappings
{
    public static class UserMapper
    {
        public static UserResponseDTO ToDto(this User user, string token = "") => new UserResponseDTO
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Role = user.Role,
            Token = token
        };

        public static UserDTO ToDto(this User user) => new UserDTO
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Role = user.Role,
            IsActive = user.IsActive
        };
    }
}