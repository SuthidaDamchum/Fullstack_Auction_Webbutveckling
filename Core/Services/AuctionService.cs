using Core.Interfaces;
using Data.Configurations;
using Data.Interfaces;
using Domain.DTOs;
using Domain.Entities;
using Domain.Mappings;
namespace Core.Services
{
    public class AuctionService : IAuctionService

    {
        private readonly IAuctionRepository _auctionRepository;

        public AuctionService(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        async Task<IEnumerable<AuctionDTO>> IAuctionService.GetAllAsync(string? search)
        {
            var auctions = await _auctionRepository.GetAllAsync(search);
            return auctions.Select(auction => AuctionMapper.ToDto(auction));
        }
    }
}
