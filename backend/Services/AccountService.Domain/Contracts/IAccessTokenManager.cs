using System.Threading.Tasks;

namespace AccountService.Domain.Contracts
{
    public interface IAccessTokenManager
    {
        string GenerateNewToken();
    }
}