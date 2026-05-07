using Core.Interfaces;
using Data.Entities;
using Data.Interfaces;
using Domain.DTOs;

namespace Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenService _tokenService;

        public AuthenticationService(IUserRepository userRepository, TokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;

        }

        public async Task<UserResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginRequestDTO.Email);

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
            var user = await _userRepository.GetUserByEmailAsync(registerDTO.Email);

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
            await _userRepository.AddUserAsync(newUser);
            await _userRepository.SaveChangesAsync();

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
            var user = await _userRepository.GetUserByIdAsync(id);

            //Kolla att den gamla strämmer

            if (user == null) throw new Exception("User not found");
            if (!BCrypt.Net.BCrypt.Verify(updatePasswordDTO.CurrentPassword, user.PasswordHash))
                throw new Exception("Current password is incorrect");

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(updatePasswordDTO.NewPassword);

            await _userRepository.SaveChangesAsync();

        }
    }
}
