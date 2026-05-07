using Core.Interfaces;
using Core.Services;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Auction_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController( IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            var result = await _authenticationService.Login(request);
            return Ok(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            var regis = await _authenticationService.Register(registerDTO);
            return Ok(regis);
        }

        [HttpPut("UpdatePassword/{id}")]
        public async Task<IActionResult> UpdatePassword(int id, [FromBody] UpdatePasswordDTO updatePasswordDTO)
        {
            await _authenticationService.UpdatePassword(id, updatePasswordDTO);
            return Ok("Password updated successfully");
        }
    }
}
