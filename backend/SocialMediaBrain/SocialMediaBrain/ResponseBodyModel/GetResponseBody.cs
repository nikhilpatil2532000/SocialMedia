namespace SocialMediaBrain.ResponseBodyModel
{
    public class GetResponseBody<TEntity> where TEntity : class
    {
        public TEntity? Entity { get; set; } = null;
        public List<TEntity> EntityList { get; set; } = new List<TEntity>();
        public bool Success { get; set; } = false;
        public string ExceptionMessage { get; set; } = string.Empty;
    }
}
