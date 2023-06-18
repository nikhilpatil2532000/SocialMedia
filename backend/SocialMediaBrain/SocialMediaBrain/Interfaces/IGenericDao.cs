using Microsoft.EntityFrameworkCore.ChangeTracking;
using SocialMediaBrain.DatabaseFirstApproach;
using SocialMediaBrain.ResponseBodyModel;

namespace SocialMediaBrain.Interfaces
{
    public interface IGenericDao<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(int id);
        Task<List<TEntity>> GetAllAsync(int take);
        Task<List<TEntity>> FilterAsync(string propertyName, object searchVal);
        Task<OperationStatus<TEntity>> AddAsync(TEntity entity);
        Task<OperationStatus<TEntity>> UpdateAsync(TEntity entity);
        Task<OperationStatus<TEntity>> DeleteAsync(TEntity entity);
        Task SaveChangesAsync();
    }
}
