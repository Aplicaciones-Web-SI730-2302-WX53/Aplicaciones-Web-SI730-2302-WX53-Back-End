using AutoMapper;
using Data;
using Learnin_center_xw53.Request;

namespace Learnin_center_xw53.Mapper;

public class RequeToAPI : Profile
{
    public RequeToAPI()
    {
        CreateMap<TutorialRequest, Tutorial>();
        CreateMap<UserRequest, User>();
        CreateMap<UserLoginRequest, User>();
    }
}