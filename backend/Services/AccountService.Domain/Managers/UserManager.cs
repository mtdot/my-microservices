using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountService.Domain.Contracts;
using AccountService.Repository.Contracts;
using AccountService.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Domain.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IRepository<User> _userRepository;

        public UserManager(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<List<User>> FindInvalidUsers()
        {
            // invalid user if age < 18 or empty name
            return await _userRepository.FindBy(user => !IsValidUser(user)).ToListAsync();
        }

        public bool IsValidUser(User user)
        {
            return user.Age > 18 && string.IsNullOrWhiteSpace(user.Name);
        }
    }
}