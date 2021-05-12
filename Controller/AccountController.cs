using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using VeXe.Common;
using VeXe.Common.Infrastructure;
using VeXe.Dto.Request;
using VeXe.Dto.Response;
using VeXe.Service;
using VeXe.Service.Impl;

namespace VeXe.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserService _userService;

        public AccountController(ILogger<AccountController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginReq request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_userService.IsValidUserCredentials(request.UserName, request.Password))
            {
                return Unauthorized();
            }

            var role = _userService.GetUserRole(request.UserName);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,request.UserName),
                new Claim(ClaimTypes.Email,request.UserName),
                new Claim(ClaimTypes.Role, role)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            
            return NoContent();
        }

        [HttpGet("user")]
        [Authorize]
        public ActionResult GetCurrentUser()
        {
            return Ok(new LoginResp
            {
                UserName = User.Identity?.Name,
                Role = User.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty
            });
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return NoContent();
        }

        [HttpPost("refresh_token")]
        [Authorize]
        public ActionResult RefreshToken([FromBody] RefreshTokenReq request)
        {
            return NoContent();
        }

        [HttpPost("impersonation")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult Impersonate([FromBody] ImpersonationRequest request)
        {
            var impersonatedRole = _userService.GetUserRole(request.UserName);
            if (string.IsNullOrWhiteSpace(impersonatedRole))
            {
                return BadRequest($"The target user [{request.UserName}] is not found.");
            }
            if (impersonatedRole == UserRoles.Admin)
            {
                return BadRequest("This action is not supported.");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,request.UserName),
                new Claim(ClaimTypes.Role, impersonatedRole)
            };

            // var jwtResult = _jwtAuthManager.GenerateTokens(request.UserName, claims, DateTime.Now);
            return Ok(new LoginResp
            {
                UserName = request.UserName,
                Role = impersonatedRole,
                // AccessToken = jwtResult.AccessToken,
                // RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }

        [HttpPost("stop_impersonation")]
        public ActionResult StopImpersonation()
        {
            var username = User.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrWhiteSpace(username))
            {
                return BadRequest("You are not impersonating anyone.");
            }

            var role = _userService.GetUserRole(username);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,username),
                new Claim(ClaimTypes.Role, role)
            };

            // var jwtResult = _jwtAuthManager.GenerateTokens(username, claims, DateTime.Now);
            return Ok(new LoginResp
            {
                UserName = username,
                Role = role,
                // AccessToken = jwtResult.AccessToken,
                // RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }
    }

    
}
