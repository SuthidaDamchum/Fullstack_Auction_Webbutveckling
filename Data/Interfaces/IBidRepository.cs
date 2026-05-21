using Domain.Entities;

namespace Data.Interfaces
{
    public interface IBidRepository
    {
        Task<Bid> AddBid(Bid bid);
        Task<IEnumerable<Bid>> GetBidsByAuctionId(int auctionId);
        Task<Bid> GetWinnerBid(int auctionId);
        Task<Bid> GetHighestBid(int auctionId);
        Task<IEnumerable<Bid>> DeleteBid(int id);
        Task<Bid> GetBidById(int id);
    }
}
