using Data.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly AuctionDbContext _context;

        public BidRepository(AuctionDbContext context)
        {
            _context = context;
        }

        public Task<Bid> AddBid(Bid bid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Bid>> DeleteBid(int auctionId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Bid>> GetBidsByAuctionId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Bid> GetHighestBid()
        {
            throw new NotImplementedException();
        }

        public Task<Bid> GetWinnerBid()
        {
            throw new NotImplementedException();
        }
    }
}
