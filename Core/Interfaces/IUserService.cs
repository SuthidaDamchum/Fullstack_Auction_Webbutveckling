namespace Core.Interfaces
{
    public interface IUserService
    {
        Task DeactivateUser(int id);
    }
}
