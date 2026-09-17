using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SlagModeServer.DTOs;
using SlagModeServer.entities.NewStructure;
using SlagModeServer.InternalLogic;
using SlagModeServer.Services;
using System.Security.Claims;

namespace SlagModeServer.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SlagModeController(SlagModeService _service, AuthService _authService) : ControllerBase
    {
        /*        /// <summary>
                /// Шифрует все пароли юзеров с применениеи использованного мной ключа
                /// </summary>
                /// <returns>nothing</returns>
                [HttpPost]
                public ActionResult HashLockUsers()
                {
                    _authService.HashLockPasswords();
                    return Ok();
                }*/

        [HttpGet]
        [Authorize]
        [Route("{jwt}")]
        public async Task<JsonResult> Decodejwt([FromRoute] string jwt)
        {
            var userName = User.FindFirst(ClaimTypes.Name).Value;
            var userID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return new(new
            {
                userName,
                userID
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserAuthorisationData userData)
        {
            if (userData == null || string.IsNullOrWhiteSpace(userData.UserName) || string.IsNullOrWhiteSpace(userData.Password))
                return BadRequest("Username and password are required");

            var token = await _authService.Authenticate(userData);

            if (token == null)
                return Unauthorized("Invalid username or password");

            return Ok(new { Token = token });
        }

        [Authorize]
        [HttpPost]
        public JsonResult Calculate([FromBody] InputKal parameters)
        {
            return new(Solver.GetTableData(parameters));
        }

        [Authorize]
        [HttpGet]
        public async Task<JsonResult> GetMaterialsAsync()
        {
            //Получать материалы и их состав
            return new(await _service.GetMaterialsAsync());
        }

        [Authorize]
        [HttpGet]
        public async Task<JsonResult> GetBlastFurnacesAsync()
        {
            return new(await _service.GetBlastFurnacesAsync());
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetOldInputAsync(int variantId)
        {
            try
            {
                var result = await _service.GetOldInputsAsync(variantId);

                if (result == null)
                    return NotFound(new { message = "Вариант с указанным ID не найден." });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ошибка на сервере", details = ex.Message });
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> EditGuideAsync(ShihtaCatalog material)
        {
            return await _service.EditGuideAsync(material) ? Ok() : BadRequest();
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> AddInputAsync(CalcDTO data)
        {
            return await _service.AddInputAsync(data) ? Ok() : BadRequest();
        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> DeleteOldInputAsync(int calcID)
        {
            return await _service.DeleteOldInputAsync(calcID) ? Ok() : BadRequest();
        }

        [Authorize]
        [HttpGet]
        public async Task<JsonResult> GetAllInputsForUserAsync(int userID)
        {
            return new(await _service.GetUserInputsAsync(userID));
        }
    }
}