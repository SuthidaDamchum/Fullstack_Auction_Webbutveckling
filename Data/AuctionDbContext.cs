using Data.Configurations;
using Domain.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options)
              : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Bid> Bids { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AuctionConfiguration());
            modelBuilder.ApplyConfiguration(new BidConfiguration());

        }
    }
}

