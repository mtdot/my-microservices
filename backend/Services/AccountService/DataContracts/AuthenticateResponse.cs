using System;
using AccountService.Repository.Models;
using Services.DataMapper;

namespace Services.DataContracts
{
    public class AuthenticateResponse
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string AccessToken { get; set; }
    }

    public static class AuthenticateResponseModelExtensions
    {
        public static AuthenticateResponse ToAuthenticateResponse(this User user)
        {
            return ObjectMapper.Instance.Map<AuthenticateResponse>(user);
        }
    }
}