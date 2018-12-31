using System.Collections.Generic;
using System.Windows.Input;
using PropertyChanged;

namespace Redmine.ViewModels.ItemViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainMenuItemViewModel
    {
        public string Name { get; set; }
        public ICommand Command { get; set; }

        public override bool Equals(object obj)
        {
            var model = obj as MainMenuItemViewModel;
            return model != null &&
                   Name == model.Name &&
                   EqualityComparer<ICommand>.Default.Equals(Command, model.Command);
        }

        public override int GetHashCode()
        {
            var hashCode = -425854648;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICommand>.Default.GetHashCode(Command);
            return hashCode;
        }
    }
}
