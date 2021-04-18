using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeXe.Dto.Request;
using VeXe.Service;

namespace VeXe.Controller
{
    
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }
        
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetList()
        {
            return Ok(await _routeService.GetList());  
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddOne([FromBody] RouteReq request)
        {
            return Ok(request);  
        }
    }
}