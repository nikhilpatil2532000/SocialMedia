namespace SocialMediaBrain.ResponseBodyModel
{
    public class DeleteResponseBody<TEntity> where TEntity : class
    {
        public int ID { get; set; } = -1;
        public bool Success { get; set; } = false;
        public int NumberOfRowsDeleted { get; set; } = -1;
        public TEntity? Entity { get; set; } = null;
        public string ExceptionMessage { get; set; } = string.Empty;
    }
}
