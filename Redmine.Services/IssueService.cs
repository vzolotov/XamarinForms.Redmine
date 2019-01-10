using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Threading.Tasks;
using AutoMapper;
using Redmine.Models.Types;
using Redmine.Services.NetworkServices;
using WebRedmine = Redmine.Net.Api.Types;
namespace Redmine.Services
{
    public class IssueService : IIssueService
    {
        private readonly IRedmineService _redmineService;
        private readonly IUserService _userService;

        public IssueService(IRedmineService redmineService, IUserService userService)
        {
            _redmineService = redmineService;
            _userService = userService;
        }

        public async Task<PaginatedObjects<Issue>> GetIssuesAsync(int limit = 25, int offset = 0)
        {
            var user = _userService.CurrentUser ?? await _userService.GetCurrentUserAsync();

            var parameters = new NameValueCollection();
            parameters.Add(Net.Api.RedmineKeys.LIMIT, limit.ToString(CultureInfo.InvariantCulture));
            parameters.Add(Net.Api.RedmineKeys.OFFSET, offset.ToString(CultureInfo.InvariantCulture));

            var result = _redmineService.GetRedmineManager().GetPaginatedObjects<Net.Api.Types.Issue>(parameters);
            var config = new MapperConfiguration(cfg => 
                cfg.CreateMap<WebRedmine.PaginatedObjects<WebRedmine.Issue>, PaginatedObjects<Issue>>());
            return config.CreateMapper().Map<PaginatedObjects<Issue>>(result);
        }
        
    }
}
