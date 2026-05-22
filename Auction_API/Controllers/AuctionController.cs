using Core.Interfaces;
using Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auction_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionService _auctionService;

        public AuctionController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        [HttpGet("GetAllAuctions")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery] string? search)
        {
            var auctions = await _auctionService.GetAllAuctionsAsync(search);
            if (auctions == null) return NotFound("No auctions found");
            return Ok(auctions);
        }

        [HttpGet("{id}/GetAuctionById")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAuctionById(int id)
        {
            var getById = await _auctionService.GetAuctionById(id);

            if (getById == null) return NotFound("No auction found");

            return Ok(getById);
        }

        [HttpPost("AddAuction")]
        [Authorize]
        public async Task<IActionResult> CreateAuction([FromBody] CreateAuctionDTO dto)
        {
            if (dto == null) return BadRequest("Invalid auction data");
            var addAuction = await _auctionService.CreateAuction(dto);
            if (addAuction == null) return BadRequest("Could not create auction");
            return Ok(addAuction);
        }

        [HttpPut("{id}/EditAuction")]
        [Authorize]
        public async Task<IActionResult> UpdateAuction(int id, [FromBody] UpdateAuctionDTO updateAuctionDTO)
        {
            var update = await _auctionService.UpdateAuction(id, updateAuctionDTO);

            if (update == null) return NotFound("Could not find the auction");

            return Ok(update);
        }


        [HttpGet("SearchClosedAuctions")]
        [AllowAnonymous]

        public async Task<IActionResult> SearchClosedAuctions([FromQuery] string? title)
        {
            var closedAuctions = await _auctionService.SearchClosedAuctions(title);
            if (closedAuctions == null) return NotFound("No closed auctions found");
            return Ok(closedAuctions);
        }

        [HttpPut("{id}/deactivate")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeactivateAuction(int id)
        {
            try
            {
                await _auctionService.DeactivateAuction(id);
                return Ok("Auction deactivated successfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }

}











