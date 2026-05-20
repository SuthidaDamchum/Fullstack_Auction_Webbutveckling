using Data.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly AuctionDbContext _context;

        public AuctionRepository(AuctionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Auction>> GetAllAsync(string? search)
        {
            var query = _context.Auctions
              .Include(a => a.CreatedBy)
              .Where(a => a.EndDate > DateTime.UtcNow);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(auction => auction.Title.Contains(search));
            }

            return await query.ToListAsync<Auction>();
        }

        public async Task<Auction> GetAuctionById(int id)
        {
            return await _context.Auctions.FindAsync(id);
        }
    }
}
