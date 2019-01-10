using System;
using System.Threading.Tasks;
using Redmine.Models.Types;
using Redmine.Services;
using Redmine.Services.NetworkServices;

namespace Redmine.ViewModels
{
    public class IssuesPageViewModel : ViewModelBase
    {
        private readonly IIssueService _issueService;
        private PaginatedObjects<Issue> _issues;

        private int _limit = 25;
        private int _offset = 0;
        public IssuesPageViewModel(IIssueService issueService)
        {
            _issueService = issueService;
        }

        public override async Task NavigateToAsync(object data)
        {
            _issues = await _issueService.GetIssuesAsync(123);
        }
    }
}
