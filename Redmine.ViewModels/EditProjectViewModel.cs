using System.Threading.Tasks;
using ReactiveUI.Fody.Helpers;
using Redmine.ViewModels.ItemViewModels;

namespace Redmine.ViewModels
{
    public class EditProjectViewModel : ViewModelBase
    {
        public override Task NavigateToAsync(object data)
        {
            Project = data as ProjectViewModel;
            return base.NavigateToAsync(data);
        }

        [Reactive] ProjectViewModel Project {get;set;}
    }
}