using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeXe.DTO.Request.Province;

namespace VeXe.Controller
{
    public class ProvinceController : BaseController
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetList()
        {
            var vm = await Mediator.Send(new ProvincesFilterReq());
            return Ok(vm);
        }


        [HttpGet]
        [Authorize]
        [Route("origin/{id}")]
        public async Task<ActionResult> GetWardsByDistrict()
        {
            var vm = await Mediator.Send(new ProvincesFilterReq());
            return Ok(vm);
        }
    }
}