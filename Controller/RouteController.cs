using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeXe.DTO.Request.Route;

namespace VeXe.Controller
{
    public class RouteController : BaseController
    {

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetList()
        {
            var vm = await Mediator.Send(new RoutesFilterReq());
            return Ok(vm);
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public async Task<ActionResult> GetOne(int id)
        {
            var vm = await Mediator.Send(new GetRouteReq()
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
            var vm = await Mediator.Send(new GetRouteReq()
            {
                Id = 0,
                OriginId = id
            });
            return Ok(vm);
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddOne([FromBody] AddRouteReq req)
        {
            var vm = await Mediator.Send(req);
            return Ok(vm);
        }

        [HttpPut]
        [Authorize]
        [Route("{id}")]
        public async Task<ActionResult> EditOne(int id, [FromBody] EditRouteReq req)
        {
            req.Id = id;
            var vm = await Mediator.Send(req);
            return Ok(vm);
        }
    }
}
