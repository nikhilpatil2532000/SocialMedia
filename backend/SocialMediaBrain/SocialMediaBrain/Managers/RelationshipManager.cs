using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialMediaBrain.DatabaseFirstApproach;
using SocialMediaBrain.Interfaces;
using SocialMediaBrain.InternalModel;

namespace SocialMediaBrain.Managers
{
    public class RelationshipManager : IRelationshipManager
    {
        private TestContext _dbContext;
        private IMapper _mapper;
        public RelationshipManager(IMapper mapper, TestContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<RelationshipModel> AddRelationshipAsync(RelationshipModel relationshipModel)
        {
            await _dbContext.Relationships.AddAsync(_mapper.Map<Relationship>(relationshipModel));
            await _dbContext.SaveChangesAsync();
            return relationshipModel;
        } 
        public async Task<RelationshipModel?> GetRelationshipAsync(int id)
        {
            RelationshipModel? relationship = _mapper.Map<RelationshipModel>(await _dbContext.Relationships.Where(relation => relation.RelationshipNo == id).FirstOrDefaultAsync());
            return relationship;
        }
        public async Task<List<RelationshipModel>> GetRelationshipsAsync()
        {
            return await _dbContext.Relationships.Select(rel => _mapper.Map<RelationshipModel>(rel)).ToListAsync();
        }

        public async Task<RelationshipModel> RemoveRelationshipAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<RelationshipModel> UpdateRelationshipAsync(int id, RelationshipModel relationshipModel)
        {
            throw new NotImplementedException();
        }
    }
}
