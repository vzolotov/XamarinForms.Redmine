using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Redmine.Services;
using System.Reactive.Linq;
using Redmine.Services.Interfaces;
using Redmine.Models;

namespace Redmine.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        private readonly ISettingsService _settingsService;
        private readonly IUserService _userService;
        private readonly IQrScannerService _qrScannerService;
        private readonly IMainView _mainViewService;

        public SettingsPageViewModel(
            ISettingsService settingsService,
            IUserService userService,
            IQrScannerService qrScannerService,
            IMainView mainViewService)
        {
            _settingsService = settingsService;
            _userService = userService;
            _qrScannerService = qrScannerService;
            _mainViewService = mainViewService;
            var canSave =
                this.WhenAnyValue(x => x.Host, x => x.ApiKey)
                .Select((arg) =>
                !string.IsNullOrWhiteSpace(arg.Item1) && !string.IsNullOrWhiteSpace(arg.Item2));

            var canScan =
                this.WhenAnyValue(x => x.Host, x => x.ApiKey)
                .Select((arg) =>
                string.IsNullOrWhiteSpace(arg.Item1) || string.IsNullOrWhiteSpace(arg.Item2));

            SaveCommand = ReactiveCommand.Create(SaveSettings, canExecute: canSave);
            ScanQrCodeCommand = ReactiveCommand.Create(ScanQrHandler);
        }

        private void ScanQrHandler()
        {
            _qrScannerService.Scan();
        }


        public override Task NavigateToAsync(object data)
        {
            if (data is ScanModel scanData)
            {
                _settingsService.Host = scanData.Host;
                _settingsService.ApiKey = scanData.Key;
                _mainViewService.GoToLogic();
                return Task.CompletedTask;
            }
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
                _mainViewService.GoToLogic();
            }
            catch
            {

            }
        }

        [Reactive] public string Host { get; set; }
        [Reactive] public string ApiKey { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand ScanQrCodeCommand { get; set; }
    }
}
