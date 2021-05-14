using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeXe.DTO.Request.Province;

namespace VeXe.Controller
{
    public class DistrictController : BaseController
    {
        [HttpGet]
        [Authorize]
        [Route("{id}/ward")]
        public async Task<ActionResult> GetWards(int id)
        {
            var vm = await Mediator.Send(new WardsFilterReq() { 
                DistrictId = id
            });
            return Ok(vm);
        }
    }
}