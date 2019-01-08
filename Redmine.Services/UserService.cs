using System;
using System.Threading.Tasks;
using Redmine.Net.Api.Async;
using Redmine.Net.Api.Types;
using Redmine.Services.NetworkServices;

namespace Redmine.Services
{
    public class UserService : IUserService
    {
        private readonly IRedmineService _redmineService;

        public UserService(IRedmineService redmineService)
        {
            _redmineService = redmineService;
        }
        
        
        public async Task<User> GetCurrentUserAsync()
        {
            var redmineUser = await _redmineService.GetRedmineManager().GetCurrentUserAsync();
            return redmineUser;
        }
    }
}
