using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SocialMediaBrain.InternalModel
{
    public class UserModel
    {
        public string UserId { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public int Gender { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public static explicit operator Task<object>(UserModel v)
        {
            throw new NotImplementedException();
        }
    }
}
