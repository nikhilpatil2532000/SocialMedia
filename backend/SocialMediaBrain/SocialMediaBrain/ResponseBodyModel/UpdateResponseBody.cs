namespace SocialMediaBrain.ResponseBodyModel
{
    public class UpdateResponseBody<TEntity> where TEntity : class
    {
        public int ID { get; set; } = -1;
        public bool Success { get; set; } = false;
        public TEntity? Entity { get; set; } = null;
        public string ExceptionMessage { get; set; } = string.Empty;

    }
}
