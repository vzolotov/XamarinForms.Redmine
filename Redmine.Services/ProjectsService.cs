using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Threading.Tasks;
using AutoMapper;
using Redmine.Models.Types;
using Redmine.Services.NetworkServices;

using WebRedmine = Redmine.Net.Api.Types;

namespace Redmine.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly IRedmineService _redmineService;
        private readonly IUserService _userService;

        public ProjectsService(IRedmineService redmineService, IUserService userService)
        {
            _redmineService = redmineService;
            _userService = userService;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            var user = _userService.CurrentUser ?? await _userService.GetCurrentUserAsync();
            var parameters = new NameValueCollection();
            parameters.Add(Net.Api.RedmineKeys.LIMIT, 25.ToString(CultureInfo.InvariantCulture));
            parameters.Add(Net.Api.RedmineKeys.OFFSET, 0.ToString(CultureInfo.InvariantCulture));
            var result = _redmineService
                .GetRedmineManager()
                .GetPaginatedObjects<WebRedmine.Project>(parameters);
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<List<WebRedmine.Project>, List<Project>>());
            return config.CreateMapper().Map<List<Project>>(result);
        }
    }
}
