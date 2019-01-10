using System;
using DryIoc;
using Redmine.ViewModels;
using Redmine.Services;
using Redmine.Services.NetworkServices;

namespace Redmine
{
    public class ViewModelResolver
    {
        protected static Container Container { get; } = new Container();
        public ViewModelResolver()
        {
           
        }

        public static MasterViewModel MasterViewModel => Container.Resolve<MasterViewModel>();
        public static IssuesPageViewModel IssuesPageViewModel => Container.Resolve<IssuesPageViewModel>();
        public static SettingsPageViewModel SettingsPageViewModel => Container.Resolve<SettingsPageViewModel>();

        public virtual void PlatformContainerInit()
        {
            ///Services
            Container.Register<INavigationService, NavigationService>(Reuse.Singleton);
            Container.Register<ISettingsService, SettingsService>(Reuse.Singleton);
            Container.Register<IRedmineService, RedmineService>(Reuse.Singleton);
            Container.Register<IUserService, UserService>(Reuse.Singleton);
            Container.Register<IIssueService, IssueService>(Reuse.Transient);

            ///ViewModels
            Container.Register<MasterViewModel>();
            Container.Register<IssuesPageViewModel>();
            Container.Register<SettingsPageViewModel>();
        }
    }
}
