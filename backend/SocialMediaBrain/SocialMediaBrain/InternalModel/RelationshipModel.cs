using Newtonsoft.Json;
using SocialMediaBrain.DatabaseFirstApproach;

namespace SocialMediaBrain.InternalModel
{
    public class RelationshipModel
    {
        [JsonProperty("RelationshipNo")]
        public int RelationshipNo { get; set; }
        [JsonProperty("UserId")]
        public int UserId { get; set; }
        [JsonProperty("FriendId")]
        public int FriendId { get; set; }
        [JsonProperty("ClosedFriend")]
        public bool ClosedFriend { get; set; }
        [JsonProperty("RelationIsActive")]
        public bool? RelationIsActive { get; set; }
        [JsonProperty("CreatedDate")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("UpdatedDate")]
        public DateTime UpdatedDate { get; set; }
        [JsonProperty("FriendModel")]
        public User FriendModel { get; set; } = null!;
        [JsonProperty("UserModel")]
        public User UserModel { get; set; } = null!;
    }
}
