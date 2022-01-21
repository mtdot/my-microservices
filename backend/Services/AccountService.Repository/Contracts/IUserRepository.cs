using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountService.Repository.Models;

namespace AccountService.Repository.Contracts
{
    public interface IUserRepository
    {
        public Task<List<User>> FindByName(string name);
        public Task<User> FindById(Guid userId);
    }
}