using System.Threading.Tasks;

namespace Redmine.ViewModels.Interfaces
{
    public interface INavigationService
    {
        Task NavigateToAsync<T>(object data) where T : ViewModelBase;
    }
}