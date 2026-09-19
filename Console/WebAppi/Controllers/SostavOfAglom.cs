using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppi.Models;
using WebAppi.Sevices;

namespace WebAppi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SostavOfAglom(AglomCalcService aglomCalcService) : ControllerBase
    {
        [HttpPost]
        public async Task<JsonResult> Calculate(InputDTO inputDTO)
        {
            return new JsonResult(await aglomCalcService.CalcAglom(inputDTO));   
        }

        [HttpGet]
        public async Task<JsonResult> GetDefaultPreset([FromQuery] int userId)
        {
            return new JsonResult(await aglomCalcService.UseDefaultPreset(userId));
        }

        [HttpGet]
        public async Task<JsonResult> GetPreset([FromQuery] int id)
        {
            return new JsonResult(await aglomCalcService.GetPreset(id));
        }

        [HttpGet]
        public async Task<JsonResult> GetHistory([FromQuery] int userId)
        {
            return new JsonResult(await aglomCalcService.GetHistory(userId));

        }

        [HttpDelete]
        public async Task<JsonResult> DeletePreset([FromQuery] int presetId)
        {
            return await aglomCalcService.DeletePreset(presetId);
        }
    }
}
