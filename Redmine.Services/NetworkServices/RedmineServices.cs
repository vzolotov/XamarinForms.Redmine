using System;
using Redmine.Net.Api;

namespace Redmine.Services.NetworkServices
{
    public class RedmineService : IRedmineService
    {
        private readonly RedmineManager _manager;
        private readonly ISettingsService _settingsService;

        public RedmineService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
            _manager = new RedmineManager(_settingsService.Host, _settingsService.ApiKey, MimeType.Json);
        }

        public RedmineManager GetRedmineManager()
        {
            return _manager;
        }
    }
}
