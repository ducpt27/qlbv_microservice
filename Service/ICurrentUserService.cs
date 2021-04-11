using System;

namespace VeXe.Service
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }

        bool IsAuthenticated { get; }
    }
}
