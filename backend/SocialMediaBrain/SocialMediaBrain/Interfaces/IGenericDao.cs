using Microsoft.EntityFrameworkCore.ChangeTracking;
using SocialMediaBrain.DatabaseFirstApproach;

namespace SocialMediaBrain.Interfaces
{
    public interface IGenericDao<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(int id);
        Task<List<TEntity>> GetAllAsync(int take);
        Task<List<TEntity>> FilterAsync(string propertyName, object searchVal);
        Task<EntityEntry<TEntity>> AddAsync(TEntity entity);
        Task<EntityEntry<TEntity>> UpdateAsync(TEntity entity);
        Task<EntityEntry<TEntity>> DeleteAsync(TEntity entity);
    }
}
