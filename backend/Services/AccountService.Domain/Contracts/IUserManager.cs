using System.Collections.Generic;
using System.Threading.Tasks;
using AccountService.Repository.Models;

namespace AccountService.Domain.Contracts
{
    public interface IUserManager
    {
        Task<List<User>> FindInvalidUsers();

        bool IsValidUser(User user);
    }
}