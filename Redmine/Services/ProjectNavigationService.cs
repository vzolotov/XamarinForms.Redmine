using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Redmine.ViewModels;
using Xamarin.Forms;
using System.Linq;
using Redmine.ViewModels.Interfaces;
using Redmine.Views;

namespace Redmine.Services
{
    public class ProjectNavigationService : IProjectNavigationService
    {
        private readonly IDictionary<Type, Type> navigationDictionary = new Dictionary<Type, Type>();

        private NavigationPage _rootPage;
        private Page _currentPage;
        private object _currentPageData;

        public ProjectNavigationService()
        {
            navigationDictionary.Add(typeof(ProjectsPageViewModel), typeof(Tasks));
            navigationDictionary.Add(typeof(NewProjectViewModel), typeof(AddProjectPage));
            navigationDictionary.Add(typeof(EditProjectViewModel), typeof(EditProjectPage));
            navigationDictionary.Add(typeof(DetailPageViewModel), typeof(DetailProject));
        }

        public bool IsGoBack { get; private set; }

        public virtual async Task NavigateToAsync<T>(object data) where T : ViewModelBase
        {
            if (_rootPage == null)
            {
                _rootPage = Application.Current.MainPage.FindByName<NavigationPage>("projects");
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
    }
}
