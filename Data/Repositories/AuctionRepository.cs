using Data.Interfaces;
using Domain.DTOs;
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

        public async Task<Auction> CreateAuction(Auction auction)
        {
            _context.Auctions.Add(auction);
            await _context.SaveChangesAsync();
            return auction;
        }

        public async Task DeactivateAuction(int id)
        {
            var closeAuction = await _context.Auctions.FindAsync(id);

            if (closeAuction == null) throw new Exception("Could not find the auction!");

            closeAuction.IsActive = false;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Auction>> GetAllAuctionsAsync(string? search)
        {
            var query = _context.Auctions
              .Include(a => a.CreatedBy)
              .Where(a => a.EndDate > DateTime.UtcNow);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(auction => auction.Title.Contains(search));
            }

            return await query.ToListAsync();
        }

        public async Task<Auction> GetAuctionById(int id)
        {
                return await _context.Auctions
               .Include(a => a.CreatedBy)    
               .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Auction>> SearchClosedAuctions(string? title)
        {
            var query = _context.Auctions
                .Where(q => q.EndDate < DateTime.UtcNow);

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(auctions => auctions.Title.Contains(title));
            }
            return await query.ToListAsync();
        }

        public async Task<Auction> UpdateAuction(int id, UpdateAuctionDTO updateAuctionDTO)
        {
            //Find ID
            var auction = await _context.Auctions.FindAsync(id);

            if (auction == null) throw new Exception("Auction not found");

            //if can change, only 
            auction.Title = updateAuctionDTO.Title;
            auction.Description = updateAuctionDTO.Description;
            auction.EndDate = updateAuctionDTO.EndDate;

            //Check bud before price can be chnaged
            var hasBids = await _context.Bids
                .AnyAsync(b => b.AuctionId == id);

            if (!hasBids)
                auction.Price = updateAuctionDTO.Price;

            await _context.SaveChangesAsync();

            return auction;
        }
    }
}
