using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Threading.Tasks;
using AutoMapper;
using Redmine.Models.Types;
using Redmine.Net.Api.Async;
using Redmine.Services.Interfaces;
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

        public async Task<PaginatedObjects<Project>> GetProjectsAsync()
        {
            var user = _userService.CurrentUser ?? await _userService.GetCurrentUserAsync();
            var parameters = new NameValueCollection
            {
                {Net.Api.RedmineKeys.LIMIT, 25.ToString(CultureInfo.InvariantCulture)},
                {Net.Api.RedmineKeys.OFFSET, 0.ToString(CultureInfo.InvariantCulture)}
            };
            var result = await _redmineService
                .GetRedmineManager()
                .GetPaginatedObjectsAsync<WebRedmine.Project>(parameters);
            var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<WebRedmine.PaginatedObjects<WebRedmine.Project>, PaginatedObjects<Project>>());
            return config.CreateMapper().Map<PaginatedObjects<Project>>(result);
        }

        public Task DeleteProject(string id)
        {
            return _redmineService.GetRedmineManager().DeleteObjectAsync<WebRedmine.Project>(id, null);
        }

        public Task EditProject(Project project)
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Project, WebRedmine.Project>());
            var webProject = config.CreateMapper().Map<WebRedmine.Project>(project);
            return _redmineService.GetRedmineManager()
                .UpdateObjectAsync<WebRedmine.Project>(webProject.Identifier, webProject);
        }
    }
}
