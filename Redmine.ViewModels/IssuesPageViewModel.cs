using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Redmine.Models.Types;
using Redmine.Services;
using Redmine.ViewModels.ItemViewModels;

namespace Redmine.ViewModels
{
    public class IssuesPageViewModel : ViewModelBase
    {
        private readonly IIssueService _issueService;

        private int _limit = 25;
        private int _offset = 0;
        public IssuesPageViewModel(IIssueService issueService)
        {
            _issueService = issueService;
        }

        public ObservableCollection<IssueViewModel> Issues { get; set; } = new ObservableCollection<IssueViewModel>();

        public override async Task NavigateToAsync(object data)
        {
            IsBusy = true;
            var issues = await _issueService.GetIssuesAsync(500);
            _offset += issues.Objects.Count;
            foreach (var item in issues.Objects)
            {
                Issues.Add(new IssueViewModel(item));
            }
            IsBusy = false;
        }
    }
}
