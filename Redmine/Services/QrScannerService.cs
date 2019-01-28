using System;
using System.Threading.Tasks;
using Redmine.Services.Interfaces;
using Redmine.ViewModels.Interfaces;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace Redmine.Services
{
    public class QrScannerService : IQrScannerService
    {
        private readonly ISettingsNavigationService _navigationService;

        public QrScannerService(ISettingsNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void Scan()
        {
            var scannerPage = new ZXingScannerPage();

            scannerPage.OnScanResult += (result) => {
                scannerPage.IsScanning = false;
                Device.BeginInvokeOnMainThread(() => {
                   
                });
            };
            _navigationService.NavigateTo<ZXingScannerPage>(scannerPage);
        }
    }
}
