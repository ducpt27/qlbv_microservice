using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeXe.Dto.Request;
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
