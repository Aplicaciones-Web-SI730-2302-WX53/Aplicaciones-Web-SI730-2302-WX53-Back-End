using AutoMapper;
using Data;
using Learnin_center_xw53.Request;
using Learnin_center_xw53.Response;

namespace Learnin_center_xw53.Mapper;

public class ModelToAPI : Profile
{
    public ModelToAPI()
    {
        CreateMap<Tutorial,TutorialRequest>();
        CreateMap<Tutorial,TutorialResponse>();
        CreateMap<User,UserResponse>();
    }
}