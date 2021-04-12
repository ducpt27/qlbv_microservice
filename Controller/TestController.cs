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

        public TestController(IExampleService exampleService)
        {
            _exampleService = exampleService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetList()
        {
            return Ok(await _exampleService.GetList());  
        }

        [HttpGet("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult> GetOne(int id)
        {
            return Ok(await _exampleService.GetOne(id));
        }
    }
}