using Core.Interfaces;
using Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auction_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            if (request == null) return BadRequest("Invalid request");
            var result = await _authenticationService.Login(request);
            return Ok(result);
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            if (registerDTO == null) return BadRequest("Invalid request");
            var regis = await _authenticationService.Register(registerDTO);
            return Ok(regis);
        }

        [HttpPut("{id}/UpdatePassword")]
        [Authorize]

        public async Task<IActionResult> UpdatePassword(int id, [FromBody] UpdatePasswordDTO updatePasswordDTO)
        {
            if (updatePasswordDTO == null) return BadRequest("Invalid request");
            await _authenticationService.UpdatePassword(id, updatePasswordDTO);
            return Ok("Password updated successfully");
        }
    }
}
