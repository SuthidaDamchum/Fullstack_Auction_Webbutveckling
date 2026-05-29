using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class BidConfiguration : IEntityTypeConfiguration<Bid>
    {
       public void Configure(EntityTypeBuilder<Bid> builder)
        {
            // Fixar varningen och sätter rätt datatyp i SQL (18 siffror totalt, 2 decimaler)
            builder.Property(b => b.Amount)
                   .HasPrecision(18, 2);
            builder.HasData(

                    new Bid { Id = 1, Amount = 3250.00m, BidTime = new DateTime(2026, 05, 10, 10, 0, 0), AuctionId = 1, UserId = 3 },
                    new Bid { Id = 2, Amount = 3500.00m, BidTime = new DateTime(2026, 05, 10, 14, 30, 0), AuctionId = 1, UserId = 4 },
                    new Bid { Id = 3, Amount = 3750.00m, BidTime = new DateTime(2026, 05, 11, 09, 15, 0), AuctionId = 1, UserId = 5 },
                    new Bid { Id = 4, Amount = 4000.00m, BidTime = new DateTime(2026, 05, 11, 20, 0, 0), AuctionId = 1, UserId = 3 },
                    new Bid { Id = 5, Amount = 2750.00m, BidTime = new DateTime(2026, 05, 12, 11, 0, 0), AuctionId = 2, UserId = 4 },
                    new Bid { Id = 6, Amount = 3000.00m, BidTime = new DateTime(2026, 05, 12, 13, 45, 0), AuctionId = 2, UserId = 5 },
                    new Bid { Id = 7, Amount = 3250.00m, BidTime = new DateTime(2026, 05, 12, 16, 20, 0), AuctionId = 2, UserId = 3 },
                    new Bid { Id = 8, Amount = 3050.00m, BidTime = new DateTime(2026, 05, 13, 08, 0, 0), AuctionId = 3, UserId = 5 },
                    new Bid { Id = 9, Amount = 3300.00m, BidTime = new DateTime(2026, 05, 13, 12, 0, 0), AuctionId = 3, UserId = 4 },
                    new Bid { Id = 10, Amount = 3550.00m, BidTime = new DateTime(2026, 05, 14, 10, 30, 0), AuctionId = 3, UserId = 3 }
                );
        }
    }
}
