using AutoMapper;
using SocialMediaBrain.InternalModel;
using SocialMediaBrain.DatabaseFirstApproach;

namespace SocialMediaBrain.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<User, UserModel>();

            CreateMap<UserModel, User> ()
                .ForMember(user => user.UserId, option => option.Ignore())
                .ForMember(user => user.UpdatedDate, option => option.Ignore())
                .ForMember(user => user.CreatedDate, option => option.Ignore()).ReverseMap();
        }
    }
}
