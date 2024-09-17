using AutoMapper;
using User.Api.Dto.Request;
using User.Api.Models;

namespace User.Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserRequest, CustomIdentityUser>();
        }
    }
}