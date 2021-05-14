namespace VeXe.Service
{
    public interface ICurrentUserService
    {
        string Username { get; }

        bool IsAuthenticated { get; }
    }
}
