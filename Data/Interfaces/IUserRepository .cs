using Data.Entities;

namespace Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(int id);
        Task AddUserAsync(User user);
        Task SaveChangesAsync();
       
    }
}
