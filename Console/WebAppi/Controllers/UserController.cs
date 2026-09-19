using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppi.Entities;
using WebAppi.Models;
using WebAppi.Sevices;

namespace WebAppi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController(UserService userService) : ControllerBase
    {
        [HttpPost]
        public async Task<JsonResult> AddUser([FromBody] AddUserDTO userDTO) 
        {
            return await userService.AddUserAsync(userDTO);
        }

        [HttpPost]
        public async Task<JsonResult> AuthUser([FromBody] AuthUserDTO userDTO)
        {
            return await userService.AuthorizeUserAsync(userDTO);
        }
    }
}
