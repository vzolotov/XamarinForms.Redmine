using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Redmine.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        public ViewModelBase()
        {
        }

        [Reactive] public bool IsBusy { get; set; }

        public virtual Task NavigateToAsync(object data) 
        {
            return Task.CompletedTask;
        }

        public virtual Task NavigateFrom()
        {
            return Task.CompletedTask;
        }
    }
}
