using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using VeXe.Config;

namespace VeXe.Service.impl
{
    public class UserServiceImpl : UserService
    {
        private readonly ILogger<UserService> _logger;


        private readonly IDictionary<string, string> _users = new Dictionary<string, string>
        {
            {"test1", "password1"},
            {"test2", "password2"},
            {"admin", "securePassword"}
        };

        // inject your database here for user validation
        public UserServiceImpl(ILogger<UserService> logger)
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