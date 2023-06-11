using Newtonsoft.Json;

namespace SocialMediaBrain.ResponseBodyModel
{
    public class GetResponseBody<TEntity> where TEntity : class
    {
        [JsonProperty("Entity")]
        public TEntity? Entity { get; set; } = null;
        [JsonProperty("EntityList")]
        public List<TEntity> EntityList { get; set; } = new List<TEntity>();
        [JsonProperty("Success")]
        public bool Success { get; set; } = false;
        [JsonProperty("ExceptionMessage")]
        public string ExceptionMessage { get; set; } = string.Empty;
    }
}
