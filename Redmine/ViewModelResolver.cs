using System;
using SimpleInjector;
namespace Redmine
{
    public class ViewModelResolver
    {
        private static Container Container { get; } = new Container();
        public ViewModelResolver()
        {
        }
    }
}
