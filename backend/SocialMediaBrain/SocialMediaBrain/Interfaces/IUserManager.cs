using Microsoft.AspNetCore.JsonPatch;
using SocialMediaBrain.InternalModel;
using SocialMediaBrain.Models;

namespace SocialMediaBrain.Interfaces
{
    public interface IUserManager
    {
        Task<UserModel> AddUser(UserModel user);
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel?> GetUserById(int id);
        Task<bool> UpdateUserProperty(int id, JsonPatchDocument jsonPatchDocument);
        Task<bool> UpdateUser(int id, UserModel value);
        Task<bool> DeleteUserById(int id);
    }
}
