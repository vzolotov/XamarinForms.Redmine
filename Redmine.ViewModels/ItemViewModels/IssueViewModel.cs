﻿using System;
using System.Collections.Generic;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Redmine.Models.Types;

namespace Redmine.ViewModels.ItemViewModels
{
    public class IssueViewModel : ReactiveObject, IEquatable<IssueViewModel>
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

        public override bool Equals(object obj)
        {
            return Equals(obj as IssueViewModel);
        }

        public bool Equals(IssueViewModel other)
        {
            return other != null &&
                   EqualityComparer<IdentifiableName>.Default.Equals(Autor, other.Autor) &&
                   Notes == other.Notes &&
                   Subject == other.Subject;
        }

        public override int GetHashCode()
        {
            var hashCode = -2029057227;
            hashCode = hashCode * -1521134295 + EqualityComparer<IdentifiableName>.Default.GetHashCode(Autor);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Notes);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Subject);
            return hashCode;
        }
    }
}
