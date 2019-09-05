using System.Threading.Tasks;

namespace Redmine.Services
{
    public interface IMessageBoxService
    {
        Task ShowMessageBox(string message);
    }
}