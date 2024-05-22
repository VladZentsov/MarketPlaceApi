using MarketPlaceBLL.DTOs;
using MarketPlaceBLL.Models;
using MarketPlaceBLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MarketPlaceApi.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUserInfo")]
        public async Task<UserDto> GetUserInfo()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = HttpContext.User.FindFirstValue(ClaimTypes.Role);
            return await _userService.GetUserDtoByIdAsync(userId);
        }
        [Authorize(Roles = "admin")]
        [HttpPost("AddRoleToUser")]
        public async Task<IActionResult> AddRoleToUser([FromBody] AddRoleModel addRoleModel)
        {
            await _userService.AddRoleToUser(addRoleModel);

            return Ok();
        }
    }
}
