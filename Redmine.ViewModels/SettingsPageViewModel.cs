using System;
using Redmine.Services;

namespace Redmine.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        private readonly ISettingsService _settingsService;

        public SettingsPageViewModel(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
    }
}
