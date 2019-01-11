using System;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Redmine.Models.Types;

namespace Redmine.ViewModels.ItemViewModels
{
    public class IssueViewModel : ReactiveObject
    {
        public IssueViewModel(Issue issue)
        {
            Subject = issue.Subject;
        }

        [Reactive] public string Subject { get; set; }
    }
}
