using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VeXe.Common;
using VeXe.DTO.Request;
using VeXe.DTO.Response;
using VeXe.Service;

namespace VeXe.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
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
        public ActionResult RefreshCookie()
        {
            //TODO
            return NoContent();
        }
    }


}
