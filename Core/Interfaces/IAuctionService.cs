using Domain.DTOs;
using Domain.Entities;

namespace Core.Interfaces
{
    public interface IAuctionService
    {
        Task<IEnumerable<AuctionDTO>> GetAllAuctionsAsync(string? search);
        Task<AuctionDTO> GetAuctionById(int id);
        Task<AuctionDTO> CreateAuction(CreateAuctionDTO dto);
        Task<AuctionDTO> UpdateAuction(int id, UpdateAuctionDTO updateAuctionDTO);
        Task<IEnumerable<AuctionDTO>> SearchClosedAuctions(string? title);
        Task DeactivateAuction(int id);
    }
}
