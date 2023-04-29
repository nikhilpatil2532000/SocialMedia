using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using SocialMediaBrain.DatabaseFirstApproach;
using SocialMediaBrain.Interfaces;
using SocialMediaBrain.InternalModel;

namespace SocialMediaBrain.Managers
{
    public class UserManager : IUserManager
    {
        private TestContext _dbContext;
        private IMapper _mapper;
        public UserManager(
            TestContext dbContext,
            IMapper mapper
        )
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
            User newUser = _mapper.Map<User>(user);
            newUser.CreatedDate = DateTime.Now;
            newUser.UpdatedDate = DateTime.Now;
            await _dbContext.Users.AddAsync(newUser);
            _dbContext.SaveChanges();
            return _mapper.Map<UserModel>(newUser);
        }
            
        public async Task<List<UserModel>> GetAllUsers()
        {
            List<UserModel> listOfUsers= await _dbContext.Users.Select(user => _mapper.Map<UserModel>(user)).ToListAsync();
            return listOfUsers;
        }

        public async Task<UserModel?> GetUserById(int id)
        {
            UserModel? userMode = _mapper.Map<UserModel>(await _dbContext.Users.Where(user => user.UserId == id).FirstOrDefaultAsync());
            return userMode;
        }

        public async Task<bool> UpdateUserProperty(int id, JsonPatchDocument jsonPatchDocument)
        {
            User? user = await _dbContext.Users.Where(i => i.UserId == id).FirstOrDefaultAsync();
            if (user != null)
            {
                user.UpdatedDate = DateTime.Now;
                jsonPatchDocument.ApplyTo(user);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateUser(int id, UserModel value)
        {
            User user = _mapper.Map<User>(value);
            int numberOfUpdatedRows = await _dbContext.Users.ExecuteUpdateAsync(s => 
                s.SetProperty(i => i.FirstName,user.FirstName)
                 .SetProperty(i => i.LastName, user.LastName)
                 .SetProperty(i => i.Email, user.Email)
                 .SetProperty(i => i.Password, user.Password)
                 .SetProperty(i => i.PhoneNumber, user.PhoneNumber)
                 .SetProperty(i => i.Gender, user.Gender)
                 .SetProperty(i => i.UpdatedDate, DateTime.Now));
            await _dbContext.SaveChangesAsync();
            return (numberOfUpdatedRows > 0) ? true : false;
        }

        public async Task<bool> DeleteUserById(int id)
        {
            int numberOfRowsDeleted = await _dbContext.Users.Where(user => user.UserId == id).ExecuteDeleteAsync();
            return (numberOfRowsDeleted > 0) ? true : false; 
        }
    }
}
