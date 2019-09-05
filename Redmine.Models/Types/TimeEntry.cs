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
    /// Availability 1.1
    /// </summary>
    public class TimeEntry : Identifiable<TimeEntry>, IEquatable<TimeEntry>
    {
        private string comments;

        /// <summary>
        /// Gets or sets the issue id to log time on.
        /// </summary>
        /// <value>The issue id.</value>
        public IdentifiableName Issue { get; set; }

        /// <summary>
        /// Gets or sets the project id to log time on.
        /// </summary>
        /// <value>The project id.</value>
        public IdentifiableName Project { get; set; }

        /// <summary>
        /// Gets or sets the date the time was spent (default to the current date).
        /// </summary>
        /// <value>The spent on.</value>
        public DateTime? SpentOn { get; set; }

        /// <summary>
        /// Gets or sets the number of spent hours.
        /// </summary>
        /// <value>The hours.</value>
        public decimal Hours { get; set; }

        /// <summary>
        /// Gets or sets the activity id of the time activity. This parameter is required unless a default activity is defined in Redmine..
        /// </summary>
        /// <value>The activity id.</value>
        public IdentifiableName Activity { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public IdentifiableName User { get; set; }

        /// <summary>
        /// Gets or sets the short description for the entry (255 characters max).
        /// </summary>
        /// <value>The comments.</value>
        public String Comments
        {
            get => comments;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Length > 255)
                    {
                        value = value.Substring(0, 255);
                    }
                }
                comments = value;
            }
        }

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
        /// Gets or sets the custom fields.
        /// </summary>
        /// <value>The custom fields.</value>
        public IList<IssueCustomField> CustomFields { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var timeEntry = new TimeEntry { Activity = Activity, Comments = Comments, Hours = Hours, Issue = Issue, Project = Project, SpentOn = SpentOn, User = User, CustomFields = CustomFields };
            return timeEntry;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[TimeEntry: {10}, Issue={0}, Project={1}, SpentOn={2}, Hours={3}, Activity={4}, User={5}, Comments={6}, CreatedOn={7}, UpdatedOn={8}, CustomFields={9}]",
                Issue, Project, SpentOn, Hours, Activity, User, Comments, CreatedOn, UpdatedOn, CustomFields, base.ToString());
        }

        public bool Equals(TimeEntry other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && string.Equals(comments, other.comments) && Equals(Issue, other.Issue) && Equals(Project, other.Project) && SpentOn.Equals(other.SpentOn) && Hours == other.Hours && Equals(Activity, other.Activity) && Equals(User, other.User) && CreatedOn.Equals(other.CreatedOn) && UpdatedOn.Equals(other.UpdatedOn) && Equals(CustomFields, other.CustomFields);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TimeEntry) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (comments != null ? comments.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Issue != null ? Issue.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Project != null ? Project.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ SpentOn.GetHashCode();
                hashCode = (hashCode * 397) ^ Hours.GetHashCode();
                hashCode = (hashCode * 397) ^ (Activity != null ? Activity.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (User != null ? User.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CreatedOn.GetHashCode();
                hashCode = (hashCode * 397) ^ UpdatedOn.GetHashCode();
                hashCode = (hashCode * 397) ^ (CustomFields != null ? CustomFields.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}