using Domain.DTOs;
using Domain.Entities;

namespace Data.Interfaces
{
    public interface IAuctionRepository
    {
        Task<IEnumerable<Auction>> GetAllAuctionsAsync(string? search);
        Task <Auction> GetAuctionById(int id);
        Task<Auction> CreateAuction(Auction auction);
        Task<Auction> UpdateAuction(int id, UpdateAuctionDTO updateAuctionDTO );
        Task<IEnumerable<Auction>> SearchClosedAuctions(string? title);
        Task DeactivateAuction(int id);
    }
}
