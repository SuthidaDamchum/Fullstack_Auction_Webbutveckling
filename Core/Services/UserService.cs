using Core.Interfaces;
using Data.Interfaces;

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
    }
}
