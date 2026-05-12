using Core.Interfaces;
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

        [HttpGet("")]
        public async Task<IActionResult> GetAllAsync([FromQuery] string? search)
        {
            var auctions = await _auctionService.GetAllAsync(search);
            return Ok(auctions);
        }
    }
}
