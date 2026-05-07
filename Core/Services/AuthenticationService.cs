using Core.Interfaces;
using Data;
using Data.Entities;
using Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;

namespace Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AuctionDbContext _context;
        private readonly TokenService _tokenService;

        public AuthenticationService(AuctionDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<UserResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == loginRequestDTO.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginRequestDTO.Password, user.PasswordHash))
                throw new Exception("Invalid email or password");

            var token = _tokenService.CreateToken(user);

            return new UserResponseDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                Token = token
            };
        }

        public async Task<UserResponseDTO> Register(RegisterDTO registerDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == registerDTO.Email);

            if (user != null)
            {
                throw new Exception("Email already exists");
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerDTO.Password);

            var newUser = new User
            {
                Name = registerDTO.Name,
                Email = registerDTO.Email,
                PasswordHash = hashedPassword,
                Role = "user",
                IsActive = true
            };
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            var token = _tokenService.CreateToken(newUser);
            return new UserResponseDTO
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Email = newUser.Email,
                Role = newUser.Role,
                Token = token
            };
        }

        public async Task UpdatePassword(int id, UpdatePasswordDTO updatePasswordDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);

            //Kolla att den gamla strämmer

            if (user == null) throw new Exception("User not found");
            if (!BCrypt.Net.BCrypt.Verify(updatePasswordDTO.CurrentPassword, user.PasswordHash))
                throw new Exception("Current password is incorrect");

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(updatePasswordDTO.NewPassword);

            await _context.SaveChangesAsync();

        }
    }
}
