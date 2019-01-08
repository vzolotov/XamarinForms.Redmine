using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Redmine.Services;

namespace Redmine.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        private readonly ISettingsService _settingsService;
        private readonly IUserService _userService;

        public SettingsPageViewModel(
            ISettingsService settingsService,
            IUserService userService)
        {
            _settingsService = settingsService;
            _userService = userService;
            SaveCommand = ReactiveCommand.CreateFromTask(SaveSettingsAsync);
        }

        private async Task SaveSettingsAsync()
        {
            try
            {
                _settingsService.Host = Host;
                _settingsService.ApiKey = ApiKey;
                var a = await _userService.GetCurrentUserAsync();
            }
            catch
            {

            }
        }

        [Reactive] public string Host { get; set; }
        [Reactive] public string ApiKey { get; set; }
        public ICommand SaveCommand { get; set; }
    }
}
