using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class AuctionConfiguration : IEntityTypeConfiguration<Auction>
    {
        public void Configure(EntityTypeBuilder<Auction> builder)
        {
            // Detta talar om för SQL Server att använda 18 siffror totalt och 2 decimaler.
            builder.Property(a => a.Price)
                .HasColumnType("decimal(18,2)");

            builder.HasData(
                            new Auction { Id = 1, UserId = 2, Title = "MacBookPro2020", Description = "Apple MacBook Pro 13 tum, 16GB RAM, 512GB SSD", Price = 8000, StartDate = new DateTime(2026, 5, 1), EndDate = new DateTime(2026, 6, 1), ImageUrl = "https://localhost:7140/1MacBookPro2020.jpg" },

                            new Auction { Id = 2, UserId = 2, Title = "iPhone 13 Pro", Description = "Apple iPhone 13 Pro 256GB, Pacific Blue", Price = 5000, StartDate = new DateTime(2026, 5, 1), EndDate = new DateTime(2026, 6, 5), ImageUrl = "https://localhost:7140/2iphone13pro.jpg" },

                            new Auction { Id = 3, UserId = 2, Title = "Gaming PC", Description = "RTX 3080, Intel i9, 32GB RAM, 1TB SSD", Price = 15000, StartDate = new DateTime(2026, 5, 1), EndDate = new DateTime(2026, 6, 3), ImageUrl = "https://localhost:7140/3GamingPC.jpg" },

                            new Auction { Id = 4, UserId = 2, Title = "Sony PlayStation 5", Description = "PS5 med två handkontroller och 5 spel", Price = 6000, StartDate = new DateTime(2026, 5, 1), EndDate = new DateTime(2026, 6, 10), ImageUrl = "https://localhost:7140/4SonyPlayStation5.jpg" },

                            new Auction { Id = 5, UserId = 2, Title = "iPad Pro 12.9", Description = "Apple iPad Pro 12.9 tum, 256GB, WiFi + Cellular", Price = 9000, StartDate = new DateTime(2026, 5, 1), EndDate = new DateTime(2026, 6, 14), ImageUrl = "https://localhost:7140/5ipad.jpg" },

                            new Auction { Id = 6, UserId = 2, Title = "Samsung 4K Monitor", Description = "Samsung 32 tum 4K UHD monitor, 144Hz", Price = 4000, StartDate = new DateTime(2026, 5, 1), EndDate = new DateTime(2026, 5, 15), ImageUrl = "https://localhost:7140/6monitor.jpg" },

                            new Auction { Id = 7, UserId = 2, Title = "DJI Drone", Description = "DJI Mavic Air 2, 4K kamera, 34 min flygtid", Price = 7000, StartDate = new DateTime(2026, 5, 1), EndDate = new DateTime(2026, 6, 6), ImageUrl = "https://localhost:7140/7DJIDrone.jpg" },

                            new Auction { Id = 8, UserId = 2, Title = "Mechanical Keyboard", Description = "Corsair K95 RGB, Cherry MX switches", Price = 1500, StartDate = new DateTime(2026, 5, 1), EndDate = new DateTime(2026, 5, 20), ImageUrl = "https://localhost:7140/8MechanicalKeyboard.jpg" },

                            new Auction { Id = 9, UserId = 2, Title = "Nintendo Switch OLED", Description = "Nintendo Switch OLED med 10 spel", Price = 3500, StartDate = new DateTime(2026, 5, 1), EndDate = new DateTime(2026, 6, 8), ImageUrl = "https://localhost:7140/9NintendoSwitchOLED.jpg" },

                            new Auction { Id = 10, UserId = 2, Title = "Apple Watch Series 7", Description = "Apple Watch Series 7, 45mm, Midnight", Price = 4500, StartDate = new DateTime(2026, 5, 1), EndDate = new DateTime(2026, 6, 12), ImageUrl = "https://localhost:7140/10applewatch.jpg" }
                                            );
        }
    }
}
