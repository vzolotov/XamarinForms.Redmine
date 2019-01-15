using System;
using System.Collections.Generic;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Redmine.Models.Types;

namespace Redmine.ViewModels.ItemViewModels
{
    public class ProjectViewModel : ReactiveObject, IEquatable<ProjectViewModel>
    {
        public ProjectViewModel(Project project)
        {
            Name = project.Name;
            Description = project.Description;
        }

        [Reactive] public string Description { get; set; }

        [Reactive] public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectViewModel);
        }

        public bool Equals(ProjectViewModel other)
        {
            return other != null &&
                   Description == other.Description &&
                   Name == other.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = -1174144137;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
