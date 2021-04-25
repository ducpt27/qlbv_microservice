

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
            // Console.WriteLine("id " + id);
            var vm = await Mediator.Send(req);
            return Ok(vm);
        }
    }
}