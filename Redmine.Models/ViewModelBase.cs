using System;
using System.Threading.Tasks;

namespace Redmine.ViewModels
{
    public class ViewModelBase
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
