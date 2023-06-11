using Newtonsoft.Json;

namespace SocialMediaBrain.ResponseBodyModel
{
    public class AddResponseBody<TEntity> where TEntity : class
    {
        [JsonProperty("ID")]
        public int ID { get; set; } = -1;
        [JsonProperty("Success")]
        public bool Success { get; set; } = false;
        [JsonProperty("Entity")]
        public TEntity? Entity { get; set; } = null;
        [JsonProperty("ExceptionMessage")]
        public string ExceptionMessage { get; set; } = string.Empty;

    }
}
