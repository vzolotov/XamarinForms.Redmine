using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Redmine.Models.Types;
using Redmine.Services;
using Redmine.Services.Interfaces;
using Redmine.ViewModels.ItemViewModels;

namespace Redmine.ViewModels
{
    public class IssuesPageViewModel : ViewModelBase
    {
        private readonly IIssueService _issueService;
        private readonly IMessageBoxService _messageBoxService;
        private int _limit = 25;
        private int _offset = 0;
        public IssuesPageViewModel(
            IIssueService issueService,
            IMessageBoxService messageBoxService)
        {
            _issueService = issueService;
            _messageBoxService = messageBoxService;
            RefreshCommand = ReactiveCommand.CreateFromTask(OnRefreshHandlerAsync);
        }

        private async Task OnRefreshHandlerAsync(CancellationToken arg)
        {
            IsRefreshing = true;
            await GetIssuesAsync(_limit, _offset);
            IsRefreshing = false;
        }

        public ObservableCollection<IssueViewModel> Issues { get; set; } = new ObservableCollection<IssueViewModel>();
        
        public ICommand RefreshCommand { get; set; }
        [Reactive] public bool IsRefreshing { get; set; }

        public override async Task NavigateToAsync(object data)
        {
            IsBusy = true;
            await GetIssuesAsync(_limit, _offset);
            IsBusy = false;
        }

        private async Task GetIssuesAsync(int limit, int offset)
        {
            var issues = await _issueService.GetIssuesAsync(limit, offset);
            _offset += issues.Objects.Count;
            foreach (var item in issues.Objects)
            {
                Issues.Add(new IssueViewModel(item));
            }
        }
    }
}
