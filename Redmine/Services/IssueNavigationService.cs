using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReactiveUI;
using Redmine.ViewModels;
using Xamarin.Forms;
using System.Linq;
using Redmine.ViewModels.Interfaces;
using Redmine.Views;

namespace Redmine.Services
{
    public class IssueNavigationService : IIssueNavigationService
    {
        private readonly IDictionary<Type, Type> navigationDictionary = new Dictionary<Type, Type>();

        private NavigationPage _rootPage;
        private Page _currentPage;
        private object _currentPageData;

        public IssueNavigationService()
        {
            navigationDictionary.Add(typeof(IssuesPageViewModel), typeof(Tasks));
            navigationDictionary.Add(typeof(SettingsPageViewModel), typeof(SettingsPage));
        }

        public bool IsGoBack { get; private set; }

        public virtual async Task NavigateToAsync<T>(object data) where T : ViewModelBase
        {
            if (_rootPage == null)
            {
                _rootPage = Application.Current.MainPage.FindByName<NavigationPage>("navigationPage");
                IsGoBack = _rootPage.Navigation.NavigationStack.Any();
            }

            var p = Application.Current.MainPage as MasterDetailPage;

            if (IsGoBack)
            {
                var page = await _rootPage.PopAsync();
            }
            var pageType = navigationDictionary[typeof(T)];
            _currentPage = (Page)Activator.CreateInstance(pageType);
            _currentPage.Appearing += Page_AppearingAsync;
            _currentPage.Disappearing += Page_Disappearing;
            _currentPageData = data;
            await _rootPage.PushAsync(_currentPage, true);
        }

        void Page_Disappearing(object sender, EventArgs e)
        {
            _currentPage.Disappearing -= Page_Disappearing;
            ViewModelBase viewModel = GetCurrentContext();
            viewModel.NavigateFrom();
        }


        void Page_AppearingAsync(object sender, EventArgs e)
        {
            _currentPage.Appearing -= Page_AppearingAsync;
            ViewModelBase viewModel = GetCurrentContext();
            viewModel?.NavigateToAsync(_currentPageData);
            _currentPageData = null;
        }

        private ViewModelBase GetCurrentContext()
        {
            return _currentPage.BindingContext as ViewModelBase;
        }

        public Task GoBack()
        {
            throw new NotImplementedException();
        }
    }
}
