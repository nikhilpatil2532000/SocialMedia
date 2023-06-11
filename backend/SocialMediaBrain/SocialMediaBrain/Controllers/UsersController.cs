using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SocialMediaBrain.Interfaces;
using SocialMediaBrain.InternalModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialMediaBrain.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserManager _userManager;

        public UsersController(
            IUserManager userManager
        )
        {
            _userManager = userManager;
        }

        // GET: api/user
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int top = 100)
        {
            return Ok(await _userManager.GetAllUsersAsync(top));
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _userManager.GetUserByIdAsync(id));
        }

        // GET api/filter
        [HttpGet("filter")]
        public async Task<IActionResult> filter([FromQuery] FilterModel userFilterModel)
        {
            return Ok(await _userManager.UserFilter(userFilterModel));
        }

        // POST api/user
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserModel user)
        {
            return Ok(await _userManager.AddUserAsync(user));
        }

        // PUT api/user/user/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UserModel value)
        {
            return Ok(await _userManager.UpdateUserAsync(id, value));
        }

        // PATCH api/user/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, JsonPatchDocument jsonPatchDocument)
        {
            return Ok(await _userManager.UpdateUserPropertyAsync(id, jsonPatchDocument));
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _userManager.DeleteUserByIdAsync(id));
        }
    }
}
