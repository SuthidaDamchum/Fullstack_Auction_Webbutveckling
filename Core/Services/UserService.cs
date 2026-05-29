using Core.Interfaces;
using Data.Interfaces;
using Domain.DTOs;
using Domain.Mappings;  
namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task DeactivateUser(int id)
        {
            await _userRepository.DeactivateUser(id);
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return users.Select(u => u.ToDto()); 
        }
   
    }
}
