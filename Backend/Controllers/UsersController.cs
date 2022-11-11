using Backend.Dtos;
using Backend.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("Users")]
    [Authorize(Roles ="Admin")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<GetUsersDto>>> GetAll()
        {
            return await _userService.GetAll();
        }
        [HttpDelete]
        [Route("Remove")]
        public async Task<ActionResult<List<GetUsersDto>>> Remove(string id)
        {
            return await _userService.Remove(id);
        }
    }
}
