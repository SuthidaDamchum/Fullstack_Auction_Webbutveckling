using Core.Interfaces;
using Domain.DTOs;
using Domain.Mappings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auction_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly IBidService _bidService;

        public BidController(IBidService bidService)
        {
            _bidService = bidService;
        }

        [HttpPost("AddBid")]
        [Authorize]
        public async Task<IActionResult> AddBid([FromBody] BidDTO bidDTO)
        {
            if (bidDTO == null) return BadRequest("Invalid bid");

            var bid = bidDTO.ToEntity();
            var addBid = await _bidService.AddBid(bid);

            if (addBid == null) return BadRequest("Could not place bid");

            return Ok(addBid);
        }

        // Hämta alla bud på en auktion
        [HttpGet("{auctionId}/GetbidsByAuctionId")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBidsByAuctionId(int auctionId)
        {
            var getBids = await _bidService.GetBidsByAuctionId(auctionId);

            if (getBids == null) return NotFound("No bids found");
            return Ok(getBids);
        }

        [HttpGet("{auctionId}/Winner")]
        [AllowAnonymous]
        public async Task<IActionResult> GetWinnerBid(int auctionId)
        {
            var getWinner = await _bidService.GetWinnerBid(auctionId);
            if (getWinner == null) return NotFound("No winner found");
            return Ok(getWinner);
        }

        [HttpGet("{auctionId}/Highestbid")]
        [AllowAnonymous]
        public async Task<IActionResult> GetHighestBid(int auctionId)
        {
            var highestBid = await _bidService.GetHighestBid(auctionId);
            if (highestBid == null) return NotFound("No bids found");
            return Ok(highestBid);
        }

        [HttpDelete("{id}")]
        [Authorize]

        public async Task<IActionResult> DeleteBid(int id)
        {
            var deleteBid = await _bidService.DeleteBid(id);

            if (deleteBid == null) return NotFound("No bid found or someone has placed a higher bid!");


            return Ok(deleteBid);
        }

        [HttpGet("{id}/GetBidById")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBidById(int id)
        {
            var getBidById = await _bidService.GetBidById(id);

            if (getBidById == null) return NotFound("No bid found");

            return Ok(getBidById);
        }
    }
}
