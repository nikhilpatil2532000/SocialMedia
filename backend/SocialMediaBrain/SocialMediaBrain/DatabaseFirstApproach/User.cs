using System;
using System.Collections.Generic;

namespace SocialMediaBrain.DatabaseFirstApproach;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public int Gender { get; set; }

    public virtual ICollection<Relationship> RelationshipFriends { get; } = new List<Relationship>();

    public virtual ICollection<Relationship> RelationshipUsers { get; } = new List<Relationship>();
}
