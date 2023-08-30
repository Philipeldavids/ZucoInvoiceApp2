using DataLayer.DTO;
using DataLayer.Interface;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<bool> AddUserAsync(User user, string Password)
        {
            var result = await _userRepository.AddUser(user, Password);
            return result;
        }

        public async Task<User> GetUserById(string userId)
        {
            var result = await _userRepository.GetUserById(userId);
            return result;
        }
        public async Task<UserResponseDTO> Login(string email, string password)
        {
            var token = await _userRepository.Login(email, password);
            return token;
        }

        public async Task<bool> Update(UserRequestDTO userRequestDTO, string userId)
        {
            var result = await _userRepository.Update(userRequestDTO, userId);
            return result;
        }

        public async Task<bool> DeleteUser(string userId)
        {
            var result = await _userRepository.DeleteUser(userId);
            return result;
        }
    }

}
