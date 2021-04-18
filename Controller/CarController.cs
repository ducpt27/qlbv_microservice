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
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }
        
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetList()
        {
            return Ok(await _carService.GetList());  
        }
    }
}