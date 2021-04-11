using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using VeXe.Config;
using VeXe.Config.Infrastructure;
using VeXe.Dto.Response;
using VeXe.Service;
using VeXe.Service.Impl;


namespace VeXe.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IExampleService _exampleService;

        public TestController(IExampleService exampleService)
        {
            _exampleService = exampleService;
        }

        [HttpGet("abc")]
        [Authorize]
        public ActionResult Abc()
        {
            var data = _exampleService.GetAbc("Duc");
            return Ok(new BaseResp
            {
                Data = data
            });
        }

        [HttpPost("abc")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult Xyz()
        {
            var data = _exampleService.GetInDbTest(1);
            return Ok(new BaseResp
            {
                Data = data
            });
        }
    }
}