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
using VeXe.Service;
using VeXe.Service.impl;


namespace VeXe.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("abc")]
        [Authorize]
        public ActionResult Abc()
        {
            return Ok("123 abc");
        }

        [HttpPost("abc")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult Xyz()
        {
            return Ok("123 xyz");
        }
    }
}