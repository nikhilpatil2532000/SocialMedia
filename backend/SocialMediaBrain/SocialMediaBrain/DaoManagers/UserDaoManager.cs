using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SocialMediaBrain.DatabaseFirstApproach;
using SocialMediaBrain.GenericDao;
using SocialMediaBrain.Interfaces;
using SocialMediaBrain.InternalModel;
using SocialMediaBrain.ResponseBodyModel;

namespace SocialMediaBrain.DaoManagers
{
    public class UserDaoManager : GenericDao<User> , IUserDaoManager
    {
        private readonly ILogger<UserDaoManager> _userLogger;
        private readonly IMapper _mapper;
        public UserDaoManager(
            IMapper mapper,
            ILogger<UserDaoManager> userLogger,
            TestContext dbContext
        ): base(dbContext)
        {
            _mapper = mapper;
            _userLogger = userLogger;
        }

        //do same for all
        public async Task<AddResponseBody<UserModel>> AddUserAsync(UserModel user)
        {
            AddResponseBody<UserModel> addResponseBody = new AddResponseBody<UserModel>();
            try
            {
                user.CreatedDate = DateTime.Now;
                user.UpdatedDate = DateTime.Now;
                var inputObj = _mapper.Map<User>(user);
                OperationStatus<User> operationStatus = await this.AddAsync(inputObj);
                if (operationStatus.State == EntityState.Added) {
                    addResponseBody.Entity = _mapper.Map<UserModel>(operationStatus.Entity);
                    addResponseBody.ID = addResponseBody.Entity.UserId;
                    addResponseBody.Success = true;
                }
            }
            catch (Exception ex)
            {
                addResponseBody.ExceptionMessage = ex.Message;
            }
            return addResponseBody;
        }

        public async Task<GetResponseBody<UserModel>> GetAllUsersAsync(int take)
        {
            GetResponseBody<UserModel> getResponseBody = new GetResponseBody<UserModel>();
            try
            {
                List<User> userList = await this.GetAllAsync(take);
                getResponseBody.EntityList = _mapper.Map<List<UserModel>>(userList);
                getResponseBody.Success = true;
            }
            catch (Exception ex)
            {
                getResponseBody.ExceptionMessage = ex.Message;
            }
            return getResponseBody;
        }

        public async Task<GetResponseBody<UserModel>> GetUserByIdAsync(int id)
        {
            GetResponseBody<UserModel> getResponseBody = new GetResponseBody<UserModel>();
            try
            {
                User? user = await this.GetByIdAsync(id);
                if(user != null)
                {
                    getResponseBody.Entity = _mapper.Map<UserModel>(user);
                    getResponseBody.Success = true;
                }
            }
            catch (Exception ex)
            {
                getResponseBody.ExceptionMessage = ex.Message;
            }
            return getResponseBody;
        }

        public async Task<GetResponseBody<UserModel>> UserFilter(FilterModel userFilterModel)
        {
            GetResponseBody<UserModel> getResponseBody = new GetResponseBody<UserModel>();
            try
            {
                List<User> userList = await this.FilterAsync(userFilterModel.PropertyName, userFilterModel.value);
                getResponseBody.EntityList = _mapper.Map<List<UserModel>>(userList);
                getResponseBody.Success = true;
            }
            catch (Exception ex)
            {
                getResponseBody.ExceptionMessage = ex.Message;
            }
            return getResponseBody;
        }

        public async Task<UpdateResponseBody<UserModel>> UpdateSingleUserPropertyAsync(int id, JsonPatchDocument jsonPatchDocument)
        {
            UpdateResponseBody<UserModel> updateResponseBody = new UpdateResponseBody<UserModel>();
            try
            {
                User? user = await this.GetByIdAsync(id);
                if (user != null)
                {
                    user.UpdatedDate = DateTime.Now;
                    jsonPatchDocument.ApplyTo(user);
                    await this.SaveChangesAsync();
                    updateResponseBody.ID = id;
                    updateResponseBody.Entity = _mapper.Map<UserModel>(user);
                    updateResponseBody.Success = true;
                }
                else {
                    throw new Exception($"User ID {id} Not Found");
                }
            }
            catch (Exception ex)
            {
                updateResponseBody.ExceptionMessage = ex.Message;
            }
            return updateResponseBody;
        }

        /*public async Task<bool> UpdateMultipleUserPropertyAsync(int id, UserModel value)
        {
            User user = _mapper.Map<User>(value);
            int numberOfUpdatedRows = await _entity.ExecuteUpdateAsync(s =>
                s.SetProperty(i => i.FirstName, user.FirstName)
                 .SetProperty(i => i.LastName, user.LastName)
                 .SetProperty(i => i.Email, user.Email)
                 .SetProperty(i => i.Password, user.Password)
                 .SetProperty(i => i.PhoneNumber, user.PhoneNumber)
                 .SetProperty(i => i.Gender, user.Gender)
                 .SetProperty(i => i.UpdatedDate, DateTime.Now));
            await this.SaveChangesAsync();
            return numberOfUpdatedRows > 0;
        }*/

        public async Task<UpdateResponseBody<UserModel>> UpdateMultipleUserPropertyAsync(int id, UserModel userModel)
        {
            UpdateResponseBody<UserModel> updateResponseBody = new UpdateResponseBody<UserModel>();
            try
            {
                User user = _mapper.Map<User>(userModel);
                user.UserId = id;
                OperationStatus<User> updatedUser = await this.UpdateAsync(user);
                updateResponseBody.Entity = _mapper.Map<UserModel>(updatedUser.Entity);
                updateResponseBody.ID = updateResponseBody.Entity.UserId;
                updateResponseBody.Success = true;
            }
            catch (Exception ex)
            {
                updateResponseBody.ExceptionMessage = ex.Message;
            }
            return updateResponseBody;
        }

        public async Task<DeleteResponseBody<UserModel>> DeleteUserByIdAsync(int id)
        {
            DeleteResponseBody<UserModel> deleteResponseBody = new DeleteResponseBody<UserModel>();
            try
            {
                User? user = await this.GetByIdAsync(id);
                if (user != null)
                {
                    OperationStatus<User> operationStatus = await this.DeleteAsync(user);

                    if (operationStatus.State != EntityState.Deleted)
                        throw new Exception($"User {id} is not deleted");

                    deleteResponseBody.Entity = _mapper.Map<UserModel>(operationStatus.Entity);
                    deleteResponseBody.ID = deleteResponseBody.Entity.UserId;
                    deleteResponseBody.Success = true;
                }
                else
                    throw new Exception($"User ID {id} Not found");
            }
            catch (Exception ex)
            {
                deleteResponseBody.ExceptionMessage = ex.Message;
            }
            return deleteResponseBody;
        }

        //Check need also fix it properly
        /*public async Task<DeleteResponseBody<UserModel>> DeleteUserByIdAsync(List<int> idList)
        {
            DeleteResponseBody<UserModel> deleteResponseBody = new DeleteResponseBody<UserModel>();
            try
            {
                int numberOfRowsDeleted =  await (from user in _dbContext.Users
                                                  join id in idList
                                                  on user.UserId equals id
                                                  select user).ExecuteDeleteAsync();
                deleteResponseBody.Success = numberOfRowsDeleted == idList.Count;
                deleteResponseBody.NumberOfRowsDeleted = numberOfRowsDeleted;
            }
            catch (Exception ex)
            {
                deleteResponseBody.ExceptionMessage = ex.Message;
            }
            return deleteResponseBody;
        }*/
    }
}
