using DryIoc;
using Redmine.Services.Interfaces;
using Redmine.Droid.Services;

namespace Redmine.Droid
{
    public class AndroidResolver : ViewModelResolver
    {
        public override void PlatformContainerInit()
        {
            base.PlatformContainerInit();
            Container.Register<ILoggerService, LoggerService>();
        }
    }
}
