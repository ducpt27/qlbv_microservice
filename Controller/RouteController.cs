using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeXe.Dto.Request;

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
        public async Task<ActionResult> AddOne([FromBody] RouteReq routeReq)
        {
            var vm = await Mediator.Send(routeReq);

            return Ok(vm);
        }
    }
}
     