namespace Data.Interfaces
{
    public interface IUserRepository
    {
        Task GetUserByEmailAsync();
        Task GetUersByIdAsync();
        Task AddUserAsync();
        Task UpdatePasswordAsync();
    }
}
