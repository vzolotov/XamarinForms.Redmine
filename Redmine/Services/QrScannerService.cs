using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Redmine.Models;
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

            scannerPage.OnScanResult += (result) =>
            {
                scannerPage.IsScanning = false;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(result.Text)))
                    {
                        var deserializer = new DataContractJsonSerializer(typeof(ScanModel));
                        var scanResult = (ScanModel)deserializer.ReadObject(ms);
                        await _navigationService.GoBackWithScanData(scanResult);
                    }
                });
            };
            _navigationService.NavigateTo<ZXingScannerPage>(scannerPage);
        }
    }
}