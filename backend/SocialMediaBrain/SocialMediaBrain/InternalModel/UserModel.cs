using Newtonsoft.Json;
using SocialMediaBrain.DatabaseFirstApproach;

namespace SocialMediaBrain.InternalModel
{
    public class UserModel
    {
        [JsonProperty("UserId")]
        public int UserId { get; set; }
        [JsonProperty("FirstName")]
        public string FirstName { get; set; } = null!;
        [JsonProperty("LastName")]
        public string LastName { get; set; } = null!;
        [JsonProperty("Email")]
        public string Email { get; set; } = null!;
        [JsonProperty("Password")]
        public string Password { get; set; } = null!;
        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; } = null!;
        [JsonProperty("CreatedDate")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("UpdatedDate")]
        public DateTime UpdatedDate { get; set; }
        [JsonProperty("Gender")]
        public int Gender { get; set; }

        public static implicit operator UserModel(User v)
        {
            throw new NotImplementedException();
        }
    }
}
