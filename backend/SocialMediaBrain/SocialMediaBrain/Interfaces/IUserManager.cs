﻿using Microsoft.AspNetCore.JsonPatch;
using SocialMediaBrain.InternalModel;
using SocialMediaBrain.ResponseBodyModel;

namespace SocialMediaBrain.Interfaces
{
    public interface IUserManager
    {
        Task<AddResponseBody<UserModel>> AddUserAsync(UserModel user);
        Task<GetResponseBody<UserModel>> GetAllUsersAsync(int top);
        Task<GetResponseBody<UserModel>> GetUserByIdAsync(int id);
        Task<GetResponseBody<UserModel>> UserFilter(FilterModel userFilterModel);
        Task<UpdateResponseBody<UserModel>> UpdateUserPropertyAsync(int id, JsonPatchDocument jsonPatchDocument);
        Task<UpdateResponseBody<UserModel>> UpdateUserAsync(int id, UserModel value);
        Task<DeleteResponseBody<UserModel>> DeleteUserByIdAsync(int id);
    }
}
