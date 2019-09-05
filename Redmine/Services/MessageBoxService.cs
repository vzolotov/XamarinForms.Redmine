using System.Threading.Tasks;
using Xamarin.Forms;

namespace Redmine.Services
{
    public class MessageBoxService : IMessageBoxService
    {
        public MessageBoxService()
        {
            
        }

        public Task ShowMessageBox(string message)
        {
            return Application.Current.MainPage.DisplayAlert(Application.Current.MainPage.Title, message, "Ok");
        }
    }
}