using System;
using System.Collections.Generic;

namespace SocialMediaBrain.Models;

public partial class Relationship
{
    public int RelationshipNo { get; set; }

    public int? UserId { get; set; }

    public int? FriendId { get; set; }

    public bool ClosedFriend { get; set; }

    public bool? RelationIsActive { get; set; }

    public virtual User? Friend { get; set; }

    public virtual User? User { get; set; }
}
