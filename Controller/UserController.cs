using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeXe.DTO.Request.User;

namespace VeXe.Controller
{
    public class UserController : BaseController
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetList()
        {
            var vm = await Mediator.Send(new UsersFilterReq());
            return Ok(vm);
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public async Task<ActionResult> GetOne(int id)
        {
            var vm = await Mediator.Send(new GetUserReq()
            {
                Id = id
            });
            return Ok(vm);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddOne([FromBody] AddUserReq req)
        {
            var vm = await Mediator.Send(req);
            return Ok(vm);
        }

        [HttpPut]
        [Authorize]
        [Route("{id}")]
        public async Task<ActionResult> EditOne(int id, [FromBody] EditUserReq req)
        {
            req.Id = id;
            var vm = await Mediator.Send(req);
            return Ok(vm);
        }
    }
}