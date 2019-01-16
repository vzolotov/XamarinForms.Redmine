using System;
using Redmine.Net.Api;
using Redmine.Services.Interfaces;

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
