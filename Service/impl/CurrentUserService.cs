using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace VeXe.Service.impl
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            Username = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
            IsAuthenticated = Username != default;
        }

        public string Username { get; }

        public bool IsAuthenticated { get; }
    }

}
