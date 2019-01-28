using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Redmine.Models;
using Redmine.ViewModels;
using Redmine.ViewModels.Interfaces;
using Redmine.Views;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace Redmine.Services
{
    public class SettingsNavigationService : ISettingsNavigationService
    {
        private readonly IDictionary<Type, Type> navigationDictionary = new Dictionary<Type, Type>();

        private NavigationPage _rootPage;

        public async Task NavigateTo<T>(T page)
        {
            if (_rootPage == null)
            {
                _rootPage = Application.Current.MainPage is NavigationPage
                        ? Application.Current.MainPage as NavigationPage
                        : Application.Current.MainPage.FindByName<NavigationPage>("settings");
            }

            if (page == null)
            {
                throw new ArgumentNullException();
            }

            var scannerPage = page as ZXingScannerPage;
            await _rootPage.PushAsync(scannerPage, true);
        }

        public async Task GoBackWithScanData(ScanModel scanModel)
        {
            await _rootPage.PopAsync();
            var page = _rootPage.Navigation.NavigationStack.Last();
            var viewModel = page.BindingContext as ViewModelBase;
            viewModel?.NavigateToAsync(scanModel);
        }
    }
}