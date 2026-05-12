using Domain.DTOs;
using Domain.Entities;

namespace Core.Interfaces
{
    public interface IAuctionService
    {
        Task<IEnumerable<AuctionDto>> GetAllAsync(string? search);
    }
}
