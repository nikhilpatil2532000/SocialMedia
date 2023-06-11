using System;
using System.Collections.Generic;

namespace SocialMediaBrain.DatabaseFirstApproach;

public partial class Relationship
{
    public int RelationshipNo { get; set; }

    public int UserId { get; set; }

    public int FriendId { get; set; }

    public bool ClosedFriend { get; set; }

    public bool? RelationIsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual User Friend { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
