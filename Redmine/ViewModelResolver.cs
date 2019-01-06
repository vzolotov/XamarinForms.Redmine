using System;
using DryIoc;
using Redmine.ViewModels;
using Redmine.Services;

namespace Redmine
{
    public class ViewModelResolver
    {
        protected static Container Container { get; } = new Container();
        public ViewModelResolver()
        {
           
        }

        public static MasterViewModel MasterViewModel => Container.Resolve<MasterViewModel>();

        public virtual void PlatformContainerInit()
        {
            ///Services
            Container.Register<INavigationService, NavigationService>(Reuse.Singleton);
            ///ViewModels
            Container.Register<MasterViewModel>();
        }
    }
}
