using DataLayer.DTO;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interface
{
    public interface IUserRepository
    {
        Task<bool> AddUser(User user, string Password);
        Task<User> GetUserById(string userId);
        Task<UserResponseDTO> Login(string email, string password);
        Task<bool> Update(UserRequestDTO userRequestDTO, string userId);
        Task<bool> DeleteUser(string userId);
    }
}
