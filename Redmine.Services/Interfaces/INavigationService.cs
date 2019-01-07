using System.Threading.Tasks;
using Redmine.ViewModels;

namespace Redmine.Services
{
    public interface INavigationService
    {
        Task NavigateToAsync<T>(object data) where T : ViewModelBase;
    }
}