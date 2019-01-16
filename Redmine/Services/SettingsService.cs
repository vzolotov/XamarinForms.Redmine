using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Redmine.Services.Interfaces;

namespace Redmine.Services
{
    public class SettingsService : ISettingsService
    {
        private ISettings AppSettings => CrossSettings.Current;

        public string Host
        {
            get => AppSettings.GetValueOrDefault(nameof(Host), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Host), value);
        }

        public string ApiKey
        {
            get => AppSettings.GetValueOrDefault(nameof(ApiKey), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(ApiKey), value);
        }
    }
}
