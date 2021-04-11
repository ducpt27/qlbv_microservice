using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace VeXe.Service.impl
{
    public class CurrentUserServiceImpl : ICurrentUserService
    {
        public CurrentUserServiceImpl(IHttpContextAccessor httpContextAccessor)
        {
            Guid.TryParse(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier), out var userId);
            UserId = userId;
            IsAuthenticated = UserId != default;
        }

        public Guid UserId { get; }

        public bool IsAuthenticated { get; }
    }

}
