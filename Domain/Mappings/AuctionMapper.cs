using System.Runtime.CompilerServices;
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
            CreatedBy = auction.CreatedBy.Name,
            Title = auction.Title,
            Description = auction.Description,
            Price = auction.Price,
            StartDate = auction.StartDate,
            EndDate = auction.EndDate,
            IsOpen = auction.IsOpen
        };
    }
}
