using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeXe.Dto.Request.Order;

namespace VeXe.Controller
{
    public class OrderController : BaseController
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetList()
        {
            var vm = await Mediator.Send(new OrdersFilterReq());
            return Ok(vm);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddOne([FromBody] AddOrderReq req)
        {
            var vm = await Mediator.Send(req);
            return Ok(vm);
        }
    }
}