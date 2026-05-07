using Domain.DTOs;

namespace Core.Interfaces
{
    public interface IAuthenticationService
    {
        //tar RegisterDTO in, returnerar UserResponseDTO ut
        Task<UserResponseDTO> Register(RegisterDTO registerDTO);

        // tar emot LoginDTO, returnerar UserResponseDTO
        Task<UserResponseDTO> Login(LoginRequestDTO loginRequestDTO);

        //UpdatePassword – tar emot userId och UpdatePasswordDTO
        Task UpdatePassword(int id, UpdatePasswordDTO updatePasswordDTO);
    }
}
