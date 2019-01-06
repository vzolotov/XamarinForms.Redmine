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
            var _navigateToSettingsCommand = ReactiveCommand.CreateFromTask(NavigateToSettingsAsync);
            MenuCollection.Add(new MainMenuItemViewModel { Name = "Tasks", Command = _navigateToTaskCommand });
            MenuCollection.Add(new MainMenuItemViewModel { Name = "Settings", Command = _navigateToSettingsCommand });
        }

        private Task NavigateToSettingsAsync()
        {
            return _navigationservice.NavigateToAsync<SettingsPageViewModel>(null);
        }

        Task NavigateToTaskAsync()
        {
            return _navigationservice.NavigateToAsync<IssuesPageViewModel>(null);
        }

    }
}
