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
            /*
             * removed date time to ignore while converting objectModel into object 
             */
            CreateMap<UserModel, User>()
                .ForMember(user => user.UserId, option => option.Ignore());

            CreateMap<Relationship, RelationshipModel>();

            CreateMap<RelationshipModel, Relationship>()
                .ForMember(relation => relation.RelationshipNo, option => option.Ignore());
        }
    }
}
