using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SocialMediaBrain.Interfaces;
using SocialMediaBrain.InternalModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialMediaBrain.Controllers
{
    [Route("api/[controller]")]
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

        // GET: api/<UsersController>
        [HttpGet("users")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userManager.GetAllUsers());
        }

        // GET api/<UsersController>/5
        [HttpGet("user/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            UserModel? user = await _userManager.GetUserById(id);
            if (user != null)
                return Ok(user);
            return NotFound($"user {id} is not found");
        }

        // POST api/<UsersController>
        [HttpPost("user")]
        public async Task<IActionResult> Post([FromBody] UserModel user)
        {
            UserModel userModel = await _userManager.AddUser(user);
            return Ok(userModel);
        }

        // PUT api/<UsersController>/user/5
        [HttpPut("user/{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UserModel value)
        {
            var temp = await _userManager.UpdateUser(id, value);
            return Ok(temp);
        }

        // PATCH api/<UsersController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, JsonPatchDocument jsonPatchDocument)
        {
            var temp = await _userManager.UpdateUserProperty(id, jsonPatchDocument);
            return Ok(temp);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("user/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var temp = await _userManager.DeleteUserById(id);
            return Ok(temp);
        }
    }
}
