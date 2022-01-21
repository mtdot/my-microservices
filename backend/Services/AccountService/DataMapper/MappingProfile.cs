using AccountService.Repository.Models;
using AutoMapper;
using Services.DataContracts;

namespace Services.DataMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, AuthenticateResponse>().ForMember(m => m.UserId, options => options.MapFrom(src => src.Id));
        }
    }
}