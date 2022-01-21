using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountService.Repository.Contracts;
using AccountService.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Repository.Implements
{
    public class UserRepository : IUserRepository
    {
        private readonly AccountDbContext _dbContext;
        
        public UserRepository(AccountDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<List<User>> FindByName(string name)
        {
            return await _dbContext.Users.Where(u => u.Name == name).ToListAsync();
        }

        public async Task<User> FindById(Guid userId)
        {
            //return FindBy
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}