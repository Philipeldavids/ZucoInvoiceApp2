using DataLayer.Database;
using DataLayer.DTO;
using DataLayer.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenGenerator _tokenGenerator;
      
        public UserRepository(UserManager<User> userManager, ITokenGenerator tokenGenerator)
        {
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
           
        }

        public async Task<bool> AddUser(User user, string Password)
        {
            
            var result = await _userManager.CreateAsync(user, Password);
            if (result.Succeeded)
            {
                return true;
            }



            var errors = string.Empty;
            foreach (var item in result.Errors)
            {
                errors += item.Description + Environment.NewLine;
            }

            throw new MissingMemberException(errors);
            
        }

        public async Task<User> GetUserById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return null;
            }
            User usr = new User();
            usr.Id = user.Id;
            usr.FirstName = user.FirstName;
            usr.LastName = user.LastName;
            usr.Email = user.Email;
            usr.PhoneNumber = user.PhoneNumber;
            usr.UserName = user.UserName;
            usr.ImageUrl = user.ImageUrl;

            return usr;
        }

        public async Task<bool> Update(UserRequestDTO userRequestDTO, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null) {
                user.UserName = userRequestDTO.UserName;
                user.PhoneNumber = userRequestDTO.Phone;
                user.FirstName = userRequestDTO.FirstName;
                user.LastName = userRequestDTO.LastName;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return true;
                }

                string errors = string.Empty;

                foreach(var error in result.Errors)
                {
                    errors += error.Description + Environment.NewLine;
                }
                throw new MissingMemberException(errors);
            }
            throw new ArgumentException("Resource not found");
        }

        public async Task<bool> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if(user != null){

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return true;
            }

            string errors = string.Empty;
            foreach(var error in result.Errors)
            {
                errors += error.Description + Environment.NewLine;
            }
            throw new MissingMemberException(errors);
            }
            throw new ArgumentException("Resource not found");

        }
        public async Task<UserResponseDTO> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, password))
                {
                   UserResponseDTO response = new UserResponseDTO();
                    response.Id = user.Id;
                    response.FirstName = user.FirstName;
                    response.LastName = user.LastName;
                    response.ImageUrl = user.ImageUrl;  
                    response.PhoneNumber = user.PhoneNumber;    
                    response.Token = _tokenGenerator.GenerateToken(user);
                    return response;
                }
            }
            return null;
        }

    }
}
