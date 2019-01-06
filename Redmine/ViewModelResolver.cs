using System;
using DryIoc;

namespace Redmine
{
    public class ViewModelResolver
    {
        protected static Container Container { get; } = new Container();
        public ViewModelResolver()
        {
        }

        public virtual void PlatformContainerInit()
        {

        }
    }
}
