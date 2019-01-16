using System;
using DryIoc;
using Redmine.ViewModels;
using Redmine.Services;
using Redmine.Services.Interfaces;
using Redmine.Services.NetworkServices;
using Redmine.ViewModels.Interfaces;

namespace Redmine
{
    public class ViewModelResolver
    {
        public static Container Container { get; } = new Container();
        public ViewModelResolver()
        {
           
        }

        public static MasterViewModel MasterViewModel => Container.Resolve<MasterViewModel>();
        public static IssuesPageViewModel IssuesPageViewModel => Container.Resolve<IssuesPageViewModel>();
        public static SettingsPageViewModel SettingsPageViewModel => Container.Resolve<SettingsPageViewModel>();
        public static ProjectsPageViewModel ProjectsPageViewModel => Container.Resolve<ProjectsPageViewModel>();

        public virtual void PlatformContainerInit()
        {
            ///Services
            Container.Register<INavigationService, NavigationService>(Reuse.Singleton);
            Container.Register<ISettingsService, SettingsService>(Reuse.Singleton);
            Container.Register<IMainView, App>(Reuse.Singleton);
            Container.Register<IRedmineService, RedmineService>(Reuse.Singleton);
            Container.Register<IUserService, UserService>(Reuse.Singleton);
            Container.Register<IIssueService, IssueService>(Reuse.Singleton);
            Container.Register<IMessageBoxService, MessageBoxService>(Reuse.Transient);
            Container.Register<IProjectsService, ProjectsService>(Reuse.Transient);

            ///ViewModels
            Container.Register<MasterViewModel>();
            Container.Register<IssuesPageViewModel>();
            Container.Register<SettingsPageViewModel>();
            Container.Register<ProjectsPageViewModel>();
        }
    }
}
