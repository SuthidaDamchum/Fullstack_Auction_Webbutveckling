using Domain.Entities;

namespace Data.Interfaces
{
    public interface IAuctionRepository
    {
        Task<IEnumerable<Auction>> GetAllAsync(string? search);
    }
}
