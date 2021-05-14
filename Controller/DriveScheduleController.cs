using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeXe.DTO.Request.DriveSchedule;

namespace VeXe.Controller
{
    [Route("api/drive_schedule")]
    public class DriveScheduleController : BaseController
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetList()
        {
            var vm = await Mediator.Send(new DriveScheduleFilterReq());
            return Ok(vm);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddOne([FromBody] AddDriveScheduleReq req)
        {
            var vm = await Mediator.Send(req);
            return Ok(vm);
        }
    }
}