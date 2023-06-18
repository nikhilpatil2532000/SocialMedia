using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SocialMediaBrain.DatabaseFirstApproach;
using SocialMediaBrain.Interfaces;
using SocialMediaBrain.ResponseBodyModel;
using System.Reflection;

namespace SocialMediaBrain.GenericDao
{
    public class GenericDao<TEntity> : IGenericDao<TEntity> where TEntity : class
    {
        protected readonly TestContext _dbContext;
        protected readonly DbSet<TEntity> _entity;
        protected GenericDao(
            TestContext dbContext
        )
        {
            _dbContext = dbContext;
            _entity = dbContext.Set<TEntity>();
        }
        public async Task<OperationStatus<TEntity>> AddAsync(TEntity entity)
        {
            OperationStatus<TEntity> operationStatus = new OperationStatus<TEntity>();
            EntityEntry<TEntity> entityObj = await _dbContext.AddAsync(entity);
            operationStatus.Entity = entityObj.Entity;
            operationStatus.State = entityObj.State;
            await this.SaveChangesAsync();
            return operationStatus;
        }
        public async Task<List<TEntity>> GetAllAsync(int take)
        {
            return await _entity.Take(take).ToListAsync();
        }
        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _entity.FindAsync(id);
        }
        public async Task<OperationStatus<TEntity>> DeleteAsync(TEntity entity)
        {
            OperationStatus<TEntity> operationStatus = new OperationStatus<TEntity>();
            EntityEntry<TEntity> entityObj = _entity.Remove(entity);
            operationStatus.Entity = entityObj.Entity;
            operationStatus.State = entityObj.State;
            await this.SaveChangesAsync();
            return operationStatus;
        }

        public async Task<List<TEntity>> FilterAsync(string propertyName, object searchVal)
        {
            List<TEntity> filteredList = new List<TEntity>();
            List<TEntity> entityList = await _entity.ToListAsync();
            foreach (var obj in entityList)
            {
                object val = this.GetPropertyValue(obj, propertyName);
                if (object.Equals(val, searchVal))
                {
                    filteredList.Add(obj);
                }
            }
            return filteredList;
        }

        public async Task<OperationStatus<TEntity>> UpdateAsync(TEntity entity)
        {
            OperationStatus<TEntity> operationStatus = new OperationStatus<TEntity>();
            EntityEntry<TEntity> entityObj = _entity.Update(entity);
            operationStatus.Entity = entityObj.Entity;
            operationStatus.State = entityObj.State;
            await this.SaveChangesAsync();
            return operationStatus;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        private object GetPropertyValue(object obj, string propertyName)
        {
            Type objType = obj.GetType();
            PropertyInfo? property = objType.GetProperty(propertyName);
            if (property != null)
            {
                return property.GetValue(obj, null) ?? new object();
            }
            else
            {
                throw new ArgumentException($"Property {propertyName} does not exist in {objType}");
            }
        }
    }
}
