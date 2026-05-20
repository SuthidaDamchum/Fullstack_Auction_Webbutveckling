using Domain.DTOs;
using Domain.Entities;

namespace Core.Interfaces
{
    public interface IAuctionService
    {
        Task<IEnumerable<AuctionDTO>> GetAllAsync(string? search);

    }
}
