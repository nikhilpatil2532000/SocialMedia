using SocialMediaBrain.InternalModel;

namespace SocialMediaBrain.Interfaces
{
    public interface IRelationshipManager
    {
        Task<List<RelationshipModel>> GetRelationshipsAsync();
        Task<RelationshipModel?> GetRelationshipAsync(int id);
        Task<RelationshipModel> AddRelationshipAsync(RelationshipModel relationshipModel);
        Task<RelationshipModel> UpdateRelationshipAsync(int id, RelationshipModel relationshipModel);
        Task<RelationshipModel> RemoveRelationshipAsync(int id);
    }
}
