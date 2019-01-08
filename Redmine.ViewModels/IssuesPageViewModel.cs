using System;
using System.Threading.Tasks;
using Redmine.Services;
using Redmine.Services.NetworkServices;

namespace Redmine.ViewModels
{
    public class IssuesPageViewModel : ViewModelBase
    {
        private readonly IRedmineService _redmineService;

        public IssuesPageViewModel(
            IRedmineService redmineService,
            ISettingsService settingsService)
        {
            _redmineService = redmineService;
        }

        public override Task NavigateTo(object data)
        {
            return base.NavigateTo(data);
        }
    }
}
