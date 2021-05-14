

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeXe.Dto.Request.Point;


namespace VeXe.Controller
{
    public class PointController : BaseController
    {
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddOne([FromBody] AddPointReq req)
        {
            var vm = await Mediator.Send(req);
            return Ok(vm);
        }

        [HttpPut]
        [Authorize]
        [Route("{id}")]
        public async Task<ActionResult> EditOne(int id, [FromBody] EditPointReq req)
        {
            req.Id = id;
            var vm = await Mediator.Send(req);
            return Ok(vm);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetList()
        {
            var vm = await Mediator.Send(new PointsFilterReq());
            return Ok(vm);
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public async Task<ActionResult> GetOne(int id)
        {
            var vm = await Mediator.Send(new GetPointReq()
            {
                Id = id,
                OriginId = 0
            });
            return Ok(vm);
        }

        [HttpGet]
        [Authorize]
        [Route("origin/{id}")]
        public async Task<ActionResult> GetOrigin(int id)
        {
            var vm = await Mediator.Send(new GetPointReq()
            {
                Id = 0,
                OriginId = id
            });
            return Ok(vm);
        }
    }
}