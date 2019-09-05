using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReactiveUI.Fody.Helpers;
using Redmine.Models.Types;
using Redmine.ViewModels.ItemViewModels;

namespace Redmine.ViewModels
{
    public class DetailPageViewModel : ViewModelBase, IEquatable<ProjectViewModel>
    {
        public override Task NavigateToAsync(object data)
        {
            var project = data as ProjectViewModel;
            if (project != null)
            {
                Identify = project.Identify;
                Name = project.Name;
                Id = project.Id;
            }
            return base.NavigateToAsync(data);
        }
        
        [Reactive] public string Identify { get; set; }
        
        [Reactive] public int Id { get; set; }
        
        [Reactive] public string Name { get; set; }
        
        [Reactive] public string Identifier { get; set; }

        [Reactive] public string Description { get; set; }

        [Reactive] public IdentifiableName Parent { get; set; }

        [Reactive] public string HomePage { get; set; }

        [Reactive] public DateTime? CreatedOn { get; set; }

        [Reactive] public DateTime? UpdatedOn { get; set; }

        [Reactive] public ProjectStatus Status { get; set; }

        [Reactive] public bool IsPublic { get; set; }

        [Reactive] public bool InheritMembers { get; set; }

        [Reactive] public IList<ProjectTracker> Trackers { get; set; }

        [Reactive] public IList<IssueCustomField> CustomFields { get; set; }

        [Reactive] public IList<ProjectIssueCategory> IssueCategories { get; set; }

        [Reactive] public IList<ProjectEnabledModule> EnabledModules { get; set; }

        [Reactive] public IList<TimeEntryActivity> TimeEntryActivities { get; set; }

        public bool Equals(ProjectViewModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return 
                   string.Equals(Identify, other.Identify, StringComparison.CurrentCulture)
                   && Id == other.Id 
                   && string.Equals(Name, other.Name, StringComparison.CurrentCulture) 
                   && string.Equals(Identifier, other.Identifier, StringComparison.CurrentCulture) 
                   && string.Equals(Description, other.Description, StringComparison.CurrentCulture) 
                   && Equals(Parent, other.Parent) && string.Equals(HomePage, other.HomePage, StringComparison.CurrentCulture) 
                   && CreatedOn.Equals(other.CreatedOn) 
                   && UpdatedOn.Equals(other.UpdatedOn) 
                   && Status == other.Status 
                   && IsPublic == other.IsPublic 
                   && InheritMembers == other.InheritMembers 
                   && Equals(Trackers, other.Trackers) 
                   && Equals(CustomFields, other.CustomFields) 
                   && Equals(IssueCategories, other.IssueCategories) 
                   && Equals(EnabledModules, other.EnabledModules) 
                   && Equals(TimeEntryActivities, other.TimeEntryActivities);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ProjectViewModel) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Identify != null ? StringComparer.CurrentCulture.GetHashCode(Identify) : 0);
                hashCode = (hashCode * 397) ^ Id;
                hashCode = (hashCode * 397) ^ (Name != null ? StringComparer.CurrentCulture.GetHashCode(Name) : 0);
                hashCode = (hashCode * 397) ^ (Identifier != null ? StringComparer.CurrentCulture.GetHashCode(Identifier) : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? StringComparer.CurrentCulture.GetHashCode(Description) : 0);
                hashCode = (hashCode * 397) ^ (Parent != null ? Parent.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (HomePage != null ? StringComparer.CurrentCulture.GetHashCode(HomePage) : 0);
                hashCode = (hashCode * 397) ^ CreatedOn.GetHashCode();
                hashCode = (hashCode * 397) ^ UpdatedOn.GetHashCode();
                hashCode = (hashCode * 397) ^ (int) Status;
                hashCode = (hashCode * 397) ^ IsPublic.GetHashCode();
                hashCode = (hashCode * 397) ^ InheritMembers.GetHashCode();
                hashCode = (hashCode * 397) ^ (Trackers != null ? Trackers.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CustomFields != null ? CustomFields.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (IssueCategories != null ? IssueCategories.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (EnabledModules != null ? EnabledModules.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TimeEntryActivities != null ? TimeEntryActivities.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}