using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using SocialMediaBrain.DatabaseFirstApproach;
using SocialMediaBrain.Interfaces;
using SocialMediaBrain.InternalModel;
using SocialMediaBrain.ResponseBodyModel;
using System.Data.Entity;

namespace SocialMediaBrain.Managers
{
    public class UserManager : IUserManager
    {
        private IMapper _mapper;
        private IUserDaoManager _userDaoManager;
        public UserManager(
            IMapper mapper,
            IUserDaoManager userDaoManager
        )
        {
            _mapper = mapper;
            _userDaoManager = userDaoManager;
        }

        public async Task<AddResponseBody<UserModel>> AddUserAsync(UserModel user)
        {
            return await _userDaoManager.AddUserAsync(user);
        }
            
        public async Task<GetResponseBody<UserModel>> GetAllUsersAsync(int take)
        {
            return await _userDaoManager.GetAllUsersAsync(take);
        }

        public async Task<GetResponseBody<UserModel>> GetUserByIdAsync(int id)
        {
            return await _userDaoManager.GetUserByIdAsync(id);
        }

        public async Task<GetResponseBody<UserModel>> UserFilter(FilterModel userFilterModel)
        {
            return await _userDaoManager.UserFilter(userFilterModel);
        }

        public async Task<UpdateResponseBody<UserModel>> UpdateUserPropertyAsync(int id, JsonPatchDocument jsonPatchDocument)
        {
            return await _userDaoManager.UpdateSingleUserPropertyAsync(id, jsonPatchDocument);
        }

        public async Task<UpdateResponseBody<UserModel>> UpdateUserAsync(int id, UserModel user)
        {
            return await _userDaoManager.UpdateMultipleUserPropertyAsync(id, user);
        }

        public async Task<DeleteResponseBody<UserModel>> DeleteUserByIdAsync(int id)
        {
            return await _userDaoManager.DeleteUserByIdAsync(id); 
        }
    }
}
