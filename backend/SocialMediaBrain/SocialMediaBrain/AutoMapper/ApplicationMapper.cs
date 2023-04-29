using AutoMapper;
using SocialMediaBrain.InternalModel;
using SocialMediaBrain.Models;

namespace SocialMediaBrain.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}
