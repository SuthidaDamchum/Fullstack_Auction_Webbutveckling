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

        public async Task<Bid> AddBid(Bid bid)
        {
            bid.BidTime = DateTime.Now;
            _context.Bids.Add(bid);
            await _context.SaveChangesAsync();
            return bid;
        }

        public async Task<IEnumerable<Bid>> DeleteBid(int bidId)
        {
            //Hitta bid
            var bid = await _context.Bids.FindAsync(bidId);

            if (bid == null) return null;

            //Finns det högre bud?
            var newBidExists = await _context.Bids
                 .AnyAsync(b => b.AuctionId == bid.AuctionId
                             && b.BidTime > bid.BidTime);
            //Finns nya budet?
            if (newBidExists) return null;

            //Tabort
            int auctionId = bid.AuctionId;
            _context.Bids.Remove(bid);
            await _context.SaveChangesAsync();

            //Returnera 
            return await _context.Bids
                .Where(b => b.AuctionId == auctionId)
                .OrderByDescending(b => b.BidTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<Bid>> GetBidsByAuctionId(int auctionId)
        {
            return await _context.Bids
                //Hämta alla bud som tillhör denna aktion
                .Where(b => b.AuctionId == auctionId)
                //Sortera högsta bud
                .OrderByDescending(b => b.Amount)
                .ToListAsync();
        }

        public async Task<Bid> GetHighestBid(int auctionId)
        {
            return await _context.Bids
                .Where(b => b.AuctionId == auctionId)
                .OrderByDescending(b => b.Amount)
                .FirstOrDefaultAsync();
        }

        public async Task<Bid> GetWinnerBid(int auctionId)
        {
            return await _context.Bids
                .Where(b => b.AuctionId == auctionId)
                .OrderByDescending(b => b.Amount)
                .FirstOrDefaultAsync();
        }

        public async Task<Bid> GetBidById(int id)
        {
            return await _context.Bids.FindAsync(id);
        }
    }
}
