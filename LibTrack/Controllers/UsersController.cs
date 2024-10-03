using LibTrack.Models;
using LibTrack.Repository.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService) 
        {
          this._userService = userService;
        }
        [HttpGet]
        [Route("GetUsersDetails")]
        public async Task<IActionResult> GetUsersDetails()
        {
            var users = await _userService.GetUserData();
            return Ok(users);
        }
        [HttpPost]
        [Route("AddNewUserInTheLib")]
        public async Task<IActionResult> AddNewUserInTheLib(User user)
        {
               await _userService.AddNewUser(user);
            return Ok("Added New User SuccessFully");
        }

        [HttpDelete]
        [Route("DeleteUserInformation")]
        public async Task<IActionResult> DeleteUserInformation(int id)
        {
          await _userService.DeleteUser(id);
            return Ok("Delete User SuccesFully");
        }
        [HttpPut]
        [Route("UpadteUserInformation")]
        public async Task<IActionResult> UpadteUserInformation(User user)
        {
            await _userService.UpdateUser(user);
            return Ok("Update User SuccesFully");
        }


        [HttpGet]
        [Route("GetUserInformation")]
        public async Task<IActionResult> GetUserInformation(int id)
        {
            var users=   await _userService.GetUserById(id);
            return Ok(users);
        }
    }
}
