/*
   Copyright 2011 - 2018 Adrian Popescu.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Collections.Generic;

namespace Redmine.Models.Types
{
    /// <summary>
    /// Availability 1.0
    /// </summary>
    public class Project : IdentifiableName, IEquatable<Project>
    {
        /// <summary>
        /// Gets or sets the identifier (Required).
        /// </summary>
        /// <value>The identifier.</value>
        public String Identifier { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public String Description { get; set; }

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>The parent.</value>
        public IdentifiableName Parent { get; set; }

        /// <summary>
        /// Gets or sets the home page.
        /// </summary>
        /// <value>The home page.</value>
        public String HomePage { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        /// <value>The created on.</value>
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the updated on.
        /// </summary>
        /// <value>The updated on.</value>
        public DateTime? UpdatedOn { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public ProjectStatus Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this project is public.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this project is public; otherwise, <c>false</c>.
        /// </value>
        /// <remarks> is exposed since 2.6.0</remarks>
        public bool IsPublic { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [inherit members].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [inherit members]; otherwise, <c>false</c>.
        /// </value>
        public bool InheritMembers { get; set; }

        /// <summary>
        /// Gets or sets the trackers.
        /// </summary>
        /// <value>
        /// The trackers.
        /// </value>
        public IList<ProjectTracker> Trackers { get; set; }

        /// <summary>
        /// Gets or sets the custom fields.
        /// </summary>
        /// <value>
        /// The custom fields.
        /// </value>
        public IList<IssueCustomField> CustomFields { get; set; }

        /// <summary>
        /// Gets or sets the issue categories.
        /// </summary>
        /// <value>
        /// The issue categories.
        /// </value>
        public IList<ProjectIssueCategory> IssueCategories { get; set; }

        /// <summary>
        /// since 2.6.0
        /// </summary>
        /// <value>
        /// The enabled modules.
        /// </value>
        public IList<ProjectEnabledModule> EnabledModules { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<TimeEntryActivity> TimeEntryActivities { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[Project: {13}, Identifier={0}, Description={1}, Parent={2}, HomePage={3}, CreatedOn={4}, UpdatedOn={5}, Status={6}, IsPublic={7}, InheritMembers={8}, Trackers={9}, CustomFields={10}, IssueCategories={11}, EnabledModules={12}]",
                Identifier, Description, Parent, HomePage, CreatedOn, UpdatedOn, Status, IsPublic, InheritMembers, Trackers, CustomFields, IssueCategories, EnabledModules, base.ToString());
        }

        public bool Equals(Project other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && string.Equals(Identifier, other.Identifier) && string.Equals(Description, other.Description) && Equals(Parent, other.Parent) && string.Equals(HomePage, other.HomePage) && CreatedOn.Equals(other.CreatedOn) && UpdatedOn.Equals(other.UpdatedOn) && Status == other.Status && IsPublic == other.IsPublic && InheritMembers == other.InheritMembers && Equals(Trackers, other.Trackers) && Equals(CustomFields, other.CustomFields) && Equals(IssueCategories, other.IssueCategories) && Equals(EnabledModules, other.EnabledModules) && Equals(TimeEntryActivities, other.TimeEntryActivities);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Project) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Identifier != null ? Identifier.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Parent != null ? Parent.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (HomePage != null ? HomePage.GetHashCode() : 0);
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