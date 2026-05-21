using Domain.DTOs;
using Domain.Entities;

namespace Domain.Mappings
{
    public static class AuctionMapper
    {
        public static AuctionDTO ToDto(this Auction auction) => new AuctionDTO
        {
            Id = auction.Id,
            UserId = auction.UserId,
            CreatedBy = auction.CreatedBy?.Name,
            Title = auction.Title,
            Description = auction.Description,
            Price = auction.Price,
            StartDate = auction.StartDate,
            EndDate = auction.EndDate,
            IsActive = auction.IsActive
        };

        public static Auction ToEntity(this CreateAuctionDTO dto) => new Auction
        {
            Title = dto.Title,
            Description = dto.Description,
            Price = dto.Price,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            IsActive = true,
            UserId = dto.UserId
        };
    }
}
