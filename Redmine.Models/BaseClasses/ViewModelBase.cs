using System;
using System.Threading.Tasks;
using ReactiveUI;

namespace Redmine.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        public ViewModelBase()
        {
        }

        public virtual Task NavigateTo(object data) 
        {
            return Task.CompletedTask;
        }

        public virtual Task NavigateFrom()
        {
            return Task.CompletedTask;
        }
    }
}
