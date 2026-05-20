using System.Collections;
using Domain.Entities;

namespace Data.Interfaces
{
    public interface IBidRepository
    {
        Task<Bid> AddBid(Bid bid);
        Task<IEnumerable<Bid>> GetBidsByAuctionId(int id);
        Task<Bid> GetWinnerBid(int auctionId);
        Task<Bid> GetHighestBid(int auctionId);
        Task<IEnumerable<Bid>> DeleteBid(int Id);
    }
}
