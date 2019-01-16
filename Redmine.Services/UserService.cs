using System;
using System.Threading.Tasks;
using AutoMapper;
using Redmine.Net.Api.Async;
using Redmine.Net.Api.Types;
using Redmine.Services.Interfaces;
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

        public Redmine.Models.Types.User CurrentUser { get; private set; }
        public async Task<Redmine.Models.Types.User> GetCurrentUserAsync()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<User, Redmine.Models.Types.User>());
            var redmineUser = await _redmineService.GetRedmineManager().GetCurrentUserAsync();
            CurrentUser = Mapper.Map<Redmine.Models.Types.User>(redmineUser);
            return CurrentUser;
        }
    }
}
