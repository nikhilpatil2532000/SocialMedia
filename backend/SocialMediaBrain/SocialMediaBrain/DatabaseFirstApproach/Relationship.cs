using System;
using System.Collections.Generic;

namespace SocialMediaBrain.DatabaseFirstApproach;

public partial class Relationship
{
    public int RelationshipId { get; }

    public int? UserId { get; set; }

    public int? FriendId { get; set; }

    public bool ClosedFriend { get; set; }

    public bool? RelationIsActive { get; set; }

    public virtual User? Friend { get; set; }

    public virtual User? User { get; set; }
}
