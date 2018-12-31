using System;
using PropertyChanged;
using System.Collections.ObjectModel;
using Redmine.ViewModels.ItemViewModels;

namespace Redmine.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MasterViewModel
    {
        public ObservableCollection<MainMenuItemViewModel> MenuCollection { get; } =
         new ObservableCollection<MainMenuItemViewModel>();

        public MasterViewModel()
        {
        }
    }
}
