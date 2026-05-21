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
            //Omvanlda DTO>Entity
            var auction = dto.ToEntity();

            //Spara
            var create = await _auctionRepository.CreateAuction(auction);

            //Return as DTO
            return create.ToDto();
        }

        public async Task DeactivateAuction(int id)
        {
            var deactivate = await _auctionRepository.GetAuctionById(id);

            if (deactivate == null) throw new Exception("Could not find the auction!");

            //inactive
            await _auctionRepository.DeactivateAuction(id);

        }

        public async Task<AuctionDTO> GetAuctionById(int id)
        {
            var auction = await _auctionRepository.GetAuctionById(id);
            if (auction == null) return null;
            return auction.ToDto();
        }

        public async Task<IEnumerable<AuctionDTO>> SearchClosedAuctions(string? title)
        {
            var closeAuctions = await _auctionRepository.SearchClosedAuctions(title);
            return closeAuctions.Select(auction => auction.ToDto());
        }

        public async Task<AuctionDTO> UpdateAuction(int id, UpdateAuctionDTO updateAuctionDTO)
        {
            var update = await _auctionRepository.UpdateAuction(id, updateAuctionDTO);
            if (update == null) throw new Exception("Auction not found!");
            return update.ToDto();
        }

        public async Task<IEnumerable<AuctionDTO>> GetAllAuctionsAsync(string? search)
        {
            var auctions = await _auctionRepository.GetAllAuctionsAsync(search);
            return auctions.Select(auction => auction.ToDto());
        }
    }
}
