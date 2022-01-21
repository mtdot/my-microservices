using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountService.Domain.Contracts;
using AccountService.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.DataContracts;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserManager _userManager;
        private readonly IAccessTokenManager _accessTokenManager;
        
        public AccountController(IUserRepository userRepository, IUserManager userManager, IAccessTokenManager accessTokenManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _accessTokenManager = accessTokenManager;
        }
        
        [HttpPost]
        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            var user = (await _userRepository.FindByName(request.Name)).FirstOrDefault();
            if (user == null || !_userManager.IsValidUser(user))
                throw new UnauthorizedAccessException("Invalid age or name!");

            var authResponse = user.ToAuthenticateResponse();
            authResponse.AccessToken = _accessTokenManager.GenerateNewToken();
            return authResponse;
        }
    }
}