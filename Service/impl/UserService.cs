using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using VeXe.Config;

namespace VeXe.Service.Impl
{
    public class UserService : IUserService
    {
        private readonly ILogger<IUserService> _logger;


        private readonly IDictionary<string, string> _users = new Dictionary<string, string>
        {
            {"test1", "ducpt"},
            {"test2", "ducpt"},
            {"admin", "admin"}
        };

        // inject your database here for user validation
        public UserService(ILogger<IUserService> logger)
        {
            _logger = logger;
        }

        public bool IsValidUserCredentials(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            return _users.TryGetValue(userName, out var p) && p == password;
        }

        public bool IsAnExistingUser(string userName)
        {
            return _users.ContainsKey(userName);
        }

        public string GetUserRole(string userName)
        {
            if (!IsAnExistingUser(userName))
            {
                return string.Empty;
            }

            return userName == "admin" ? UserRoles.Admin : UserRoles.BasicUser;
        }
    }
}