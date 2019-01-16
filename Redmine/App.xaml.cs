using System;
using Redmine.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DryIoc;
using Redmine.Services.Interfaces;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Redmine
{
    public partial class App : Application, IMainView
    {
        public App()
        {
            InitializeComponent();
            var settings = ViewModelResolver.Container.Resolve<ISettingsService>();
            MainPage = string.IsNullOrWhiteSpace(settings.Host) || string.IsNullOrWhiteSpace(settings.ApiKey)
                ? (Page)new SettingsPage()
                : new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public void GoToLogin()
        {
            MainPage = new SettingsPage();
        }

        public void GoToLogic()
        {
            MainPage = new MainPage();
        }
    }
}
