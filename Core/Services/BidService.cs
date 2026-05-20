using Core.Interfaces;
using Data.Interfaces;
using Domain.DTOs;
using Domain.Entities;
using Domain.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class BidServicev : IBidService
    {
        private readonly IBidRepository _bidRepository;
        private readonly IAuctionRepository _auctionRepository;

    
        public BidServicev(IBidRepository bidRepository, IAuctionRepository auctionRepository)
        {
            _bidRepository = bidRepository;
            _auctionRepository = auctionRepository;
        }

        public async Task<BidDTO> AddBid(Bid bid)
        {
            //Check if the auction is open?
            var auction = await _auctionRepository.GetAuctionById(bid.AuctionId);
            if (auction == null || !auction.IsOpen)
                throw new Exception("The auction is not opend!");

            //Check if owner bid thier own auction?
            if (auction.UserId == bid.UserId)
                throw new Exception("You can't bid on your own auction!");
            //check if budget is enough?
            var highestBid = await _bidRepository.GetHighestBid(bid.AuctionId);
            if (highestBid != null && bid.Amount <= highestBid.Amount)
                throw new Exception("The bid is too low!");

            //Add
            var addedBid = await _bidRepository.AddBid(bid);
            //Return BidDto
            return addedBid.ToDto();
        }


        public Task<IEnumerable<BidDTO>> DeleteBid(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BidDTO>> GetBidsByAuctionId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BidDTO> GetHighestBid(int auctionId)
        {
            throw new NotImplementedException();
        }

        public Task<BidDTO> GetWinnerBid(int auctionId)
        {
            throw new NotImplementedException();
        }
    }
}
