using System;
using Redmine.Services.Interfaces;
using DryIoc;
using Redmine.MacOs.Services;

namespace Redmine.MacOs
{
    public class MacOsResolver : ViewModelResolver
    {
        public override void PlatformContainerInit()
        {
            base.PlatformContainerInit();
            Container.Register<ILoggerService, LoggerService>();
        }
    }
}
