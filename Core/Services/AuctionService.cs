using Core.Interfaces;
using Data.Interfaces;
using Domain.DTOs;
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

        public async Task<AuctionDTO> CreateAuction(CreateAuctionDTO dto)
        {
            var auction = dto.ToEntity();
            var createAuction = await _auctionRepository.CreateAuction(auction);
            return createAuction.ToDto();
        }

        public async Task DeactivateAuction(int id)
        {
            await _auctionRepository.DeactivateAuction(id);
        }

        public async Task<AuctionDTO> GetAuctionById(int id)
        {
            var getAuctionById = await _auctionRepository.GetAuctionById(id);
            if (getAuctionById == null) return null;
            return getAuctionById.ToDto();
        }

        public async Task<IEnumerable<AuctionDTO>> SearchClosedAuctions(string? title)
        {
            var closeAuction = await _auctionRepository.SearchClosedAuctions(title);
            if (closeAuction == null) return null;
            return closeAuction.Select(a => a.ToDto());
        }

        public async Task<AuctionDTO> UpdateAuction(int id, UpdateAuctionDTO updateAuctionDTO)
        {
            var update = await _auctionRepository.UpdateAuction(id, updateAuctionDTO);
            if (update == null) return null;
            return update.ToDto();
            
        }

        public async Task<IEnumerable<AuctionDTO>> GetAllAuctionsAsync(string? search)
        {
            var auctions = await _auctionRepository.GetAllAuctionsAsync(search);
            return auctions.Select(auction => auction.ToDto());
        }
    }
}
