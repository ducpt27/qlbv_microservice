using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeXe.Dto.Request.Car;
using VeXe.DTO.Request.Car;

namespace VeXe.Controller
{
    public class CarController: BaseController
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetList()
        {
            var vm = await Mediator.Send(new CarsFilterReq());
            return Ok(vm);
        }
        
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddOne([FromBody] AddCarReq req)
        {
            var vm = await Mediator.Send(req);
            return Ok(vm);
        }
        [HttpPut]
        [Authorize]
        [Route("{id}")]
        public async Task<ActionResult> EditOne(int id, [FromBody] EditCarReq req)
        {
            req.Id = id;
            var vm = await Mediator.Send(req);
            return Ok(vm);
        }
    }
}