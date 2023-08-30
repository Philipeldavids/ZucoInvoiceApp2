using DataLayer.DTO;
using Models;
using Models.DTO;

namespace BusinessLayer.Services
{
    public interface IUserService
    {
        Task<bool> AddUserAsync(User user, string Password);

        Task<User> GetUserById(string userId);
        Task<bool> Update(UserRequestDTO userRequestDTO, string userId);

        Task<bool> DeleteUser(string userId);
        Task<UserResponseDTO> Login(string email, string password);
    }
}