using Domain.DTOs;
using Domain.Entities;

namespace Core.Interfaces
{
    public interface IBidService
    {
        Task<BidDTO> AddBid(Bid bid);
        Task<IEnumerable<BidDTO>> GetBidsByAuctionId(int auctionId);
        Task<BidDTO> GetWinnerBid(int auctionId);
        Task<BidDTO> GetHighestBid(int auctionId);
        Task<IEnumerable<BidDTO>> DeleteBid(int id);
        Task<BidDTO>GetBidById(int id);
    }
}
