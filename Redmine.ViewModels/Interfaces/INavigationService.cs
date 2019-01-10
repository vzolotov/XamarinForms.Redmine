using System.Threading.Tasks;

namespace Redmine.ViewModels
{
    public interface INavigationService
    {
        Task NavigateToAsync<T>(object data) where T : ViewModelBase;
    }
}