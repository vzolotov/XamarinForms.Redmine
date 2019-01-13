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
            Notes = issue.Notes;
            Autor = issue.Author;
        }

        [Reactive] public IdentifiableName Autor { get; set; }

        [Reactive] public string Notes { get; set; }

        [Reactive] public string Subject { get; set; }
    }
}
