using System;
using Redmine.Services.Interfaces;
using DryIoc;
using Redmine.iOS.Services;

namespace Redmine.iOS
{
    public class IOsResolver : ViewModelResolver
    {
        public override void PlatformContainerInit()
        {
            base.PlatformContainerInit();
            Container.Register<ILoggerService, LoggerService>();
        }
    }
}
