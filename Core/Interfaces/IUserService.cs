
using Domain.DTOs;

namespace Core.Interfaces
{
    public interface IUserService
    {
        Task DeactivateUser(int id);
        Task<IEnumerable<UserDTO>> GetAllUsers();
    }
}
