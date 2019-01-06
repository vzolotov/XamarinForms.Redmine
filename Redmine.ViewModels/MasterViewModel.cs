using System;
using PropertyChanged;
using System.Collections.ObjectModel;
using Redmine.ViewModels.ItemViewModels;
using Redmine.Services;
using ReactiveUI;
using System.Reactive;
using System.Threading.Tasks;

namespace Redmine.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MasterViewModel : ViewModelBase
    {
        private INavigationService _navigationservice;

        public ObservableCollection<MainMenuItemViewModel> MenuCollection { get; } =
         new ObservableCollection<MainMenuItemViewModel>();

        public MasterViewModel(INavigationService navigationService)
        {
            _navigationservice = navigationService;

            var _navigateToTaskCommand = ReactiveCommand.CreateFromTask(NavigateToTaskAsync);
            MenuCollection.Add(new MainMenuItemViewModel { Name = "11111", Command = _navigateToTaskCommand });
        }

        Task NavigateToTaskAsync()
        {
            return _navigationservice.NavigateToAsync<IssuesPageViewModel>(null);
        }

    }
}
