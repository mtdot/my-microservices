using System;
using System.Threading.Tasks;
using AccountService.Domain.Contracts;

namespace AccountService.Domain.Managers
{
    public class AccessTokenManager : IAccessTokenManager
    {
        public AccessTokenManager()
        {
            
        }

        public string GenerateNewToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}