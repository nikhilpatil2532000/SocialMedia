using Microsoft.EntityFrameworkCore;

namespace SocialMediaBrain.ResponseBodyModel
{
    public class OperationStatus<TEntity> where TEntity : class
    {
        public EntityState State { get; set; } = EntityState.Unchanged;
        public TEntity Entity { get; set; }
    }
}
