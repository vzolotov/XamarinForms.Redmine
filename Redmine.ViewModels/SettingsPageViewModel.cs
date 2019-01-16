﻿using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Redmine.Services;
using System.Reactive.Linq;
using Redmine.Services.Interfaces;

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
            var canSave =
                this.WhenAnyValue(x => x.Host, x => x.ApiKey)
                .Select((arg) =>
                !string.IsNullOrWhiteSpace(arg.Item1) && !string.IsNullOrWhiteSpace(arg.Item2));

            SaveCommand = ReactiveCommand.Create(SaveSettings, canExecute: canSave);
        }

        public override Task NavigateToAsync(object data)
        {
            Host = _settingsService.Host;
            ApiKey = _settingsService.ApiKey;

            return base.NavigateToAsync(data);
        }

        private void SaveSettings()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Host)
                    || string.IsNullOrWhiteSpace(ApiKey))
                    return;

                _settingsService.Host = Host;
                _settingsService.ApiKey = ApiKey;
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
