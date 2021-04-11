using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using VeXe.Common;
using VeXe.Common.Infrastructure;
using VeXe.Common.Persistence;
using VeXe.DTO;
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
        private IApplicationDbContext _dbContext;  

        public TestController(IExampleService exampleService, IApplicationDbContext dbContext)
        {
            _exampleService = exampleService;
            _dbContext = dbContext;
        }

        [HttpGet("abc")]
        [Authorize]
        public ActionResult Abc()
        {
            var data = _exampleService.GetAbc("Duc");
            return Ok(this._dbContext.Abcs.ToList());  
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