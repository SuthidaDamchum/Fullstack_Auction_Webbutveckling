using System.Runtime.CompilerServices;
using Domain.DTOs;
using Domain.Entities;

namespace Domain.Mappings
{
    public static class BidMapper
    {
        public static BidDTO ToDto(this Bid bid) => new BidDTO
        {
            Id = bid.Id,
            Amount = bid.Amount,
            BidTime = bid.BidTime,
            AuctionId = bid.AuctionId,
            UserId = bid.UserId
        };

        public static Bid ToEntity(this BidDTO bidDTO) => new Bid
        {
            Amount = bidDTO.Amount,
            AuctionId = bidDTO.AuctionId,
            UserId = bidDTO.UserId
        };
    }
}
