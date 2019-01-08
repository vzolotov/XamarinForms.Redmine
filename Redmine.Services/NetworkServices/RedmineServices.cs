using System;
using Redmine.Net.Api;

namespace Redmine.Services.NetworkServices
{
    public class RedmineService : IRedmineService
    {
        private readonly ISettingsService _settingsService;

        public RedmineService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public RedmineManager GetRedmineManager()
        {
            return new RedmineManager(_settingsService.Host, _settingsService.ApiKey);
        }
    }
}
