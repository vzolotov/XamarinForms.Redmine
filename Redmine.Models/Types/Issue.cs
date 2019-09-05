/*
   Copyright 2011 - 2017 Adrian Popescu, Dorin Huzum.

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
    /// Available as of 1.1 :
    ///include: fetch associated data (optional). 
    ///Possible values: children, attachments, relations, changesets and journals. To fetch multiple associations use comma (e.g ?include=relations,journals). 
    /// See Issue journals for more information.
    /// </summary>
    public class Issue : Identifiable<Issue>, IEquatable<Issue>
    {
        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        /// <value>The project.</value>
        public IdentifiableName Project { get; set; }

        /// <summary>
        /// Gets or sets the tracker.
        /// </summary>
        /// <value>The tracker.</value>
        public IdentifiableName Tracker { get; set; }

        /// <summary>
        /// Gets or sets the status.Possible values: open, closed, * to get open and closed issues, status id
        /// </summary>
        /// <value>The status.</value>
        public IdentifiableName Status { get; set; }

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        /// <value>The priority.</value>
        public IdentifiableName Priority { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>The author.</value>
        public IdentifiableName Author { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        public IdentifiableName Category { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>The subject.</value>
        public String Subject { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public String Description { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the due date.
        /// </summary>
        /// <value>The due date.</value>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Gets or sets the done ratio.
        /// </summary>
        /// <value>The done ratio.</value>
        public float? DoneRatio { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [private notes].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [private notes]; otherwise, <c>false</c>.
        /// </value>
        public bool PrivateNotes { get; set; }

        /// <summary>
        /// Gets or sets the estimated hours.
        /// </summary>
        /// <value>The estimated hours.</value>
        public float? EstimatedHours { get; set; }

        /// <summary>
        /// Gets or sets the hours spent on the issue.
        /// </summary>
        /// <value>The hours spent on the issue.</value>
        public float? SpentHours { get; set; }

        /// <summary>
        /// Gets or sets the custom fields.
        /// </summary>
        /// <value>The custom fields.</value>
        public IList<IssueCustomField> CustomFields { get; set; }

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
        /// Gets or sets the closed on.
        /// </summary>
        /// <value>The closed on.</value>
        public DateTime? ClosedOn { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user to assign the issue to (currently no mechanism to assign by name).
        /// </summary>
        /// <value>
        /// The assigned to.
        /// </value>
        public IdentifiableName AssignedTo { get; set; }

        /// <summary>
        /// Gets or sets the parent issue id. Only when a new issue is created this property shall be used.
        /// </summary>
        /// <value>
        /// The parent issue id.
        /// </value>
        public IdentifiableName ParentIssue { get; set; }

        /// <summary>
        /// Gets or sets the fixed version.
        /// </summary>
        /// <value>
        /// The fixed version.
        /// </value>
        public IdentifiableName FixedVersion { get; set; }

        /// <summary>
        /// indicate whether the issue is private or not
        /// </summary>
        /// <value>
        /// <c>true</c> if this issue is private; otherwise, <c>false</c>.
        /// </value>
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Returns the sum of spent hours of the task and all the subtasks.
        /// </summary>
        /// <remarks>Availability starting with redmine version 3.3</remarks>
        public float? TotalSpentHours { get; set; }

        /// <summary>
        /// Returns the sum of estimated hours of task and all the subtasks.
        /// </summary>
        /// <remarks>Availability starting with redmine version 3.3</remarks>
        public float? TotalEstimatedHours { get; set; }

        /// <summary>
        /// Gets or sets the journals.
        /// </summary>
        /// <value>
        /// The journals.
        /// </value>
        public IList<Journal> Journals { get; set; }

        /// <summary>
        /// Gets or sets the changesets.
        /// </summary>
        /// <value>
        /// The changesets.
        /// </value>
        public IList<ChangeSet> Changesets { get; set; }

        /// <summary>
        /// Gets or sets the attachments.
        /// </summary>
        /// <value>
        /// The attachments.
        /// </value>
        public IList<Attachment> Attachments { get; set; }

        /// <summary>
        /// Gets or sets the issue relations.
        /// </summary>
        /// <value>
        /// The issue relations.
        /// </value>
        public IList<IssueRelation> Relations { get; set; }

        /// <summary>
        /// Gets or sets the issue children.
        /// </summary>
        /// <value>
        /// The issue children.
        /// NOTE: Only Id, tracker and subject are filled.
        /// </value>
        public IList<IssueChild> Children { get; set; }

        /// <summary>
        /// Gets or sets the attachments.
        /// </summary>
        /// <value>
        /// The attachment.
        /// </value>
        public IList<Upload> Uploads { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<Watcher> Watchers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[Issue: {30}, Project={0}, Tracker={1}, Status={2}, Priority={3}, Author={4}, Category={5}, Subject={6}, Description={7}, StartDate={8}, DueDate={9}, DoneRatio={10}, PrivateNotes={11}, EstimatedHours={12}, SpentHours={13}, CustomFields={14}, CreatedOn={15}, UpdatedOn={16}, ClosedOn={17}, Notes={18}, AssignedTo={19}, ParentIssue={20}, FixedVersion={21}, IsPrivate={22}, Journals={23}, Changesets={24}, Attachments={25}, Relations={26}, Children={27}, Uploads={28}, Watchers={29}]",
                Project, Tracker, Status, Priority, Author, Category, Subject, Description, StartDate, DueDate, DoneRatio, PrivateNotes,
                EstimatedHours, SpentHours, CustomFields, CreatedOn, UpdatedOn, ClosedOn, Notes, AssignedTo, ParentIssue, FixedVersion,
                IsPrivate, Journals, Changesets, Attachments, Relations, Children, Uploads, Watchers, base.ToString());
        }

        public bool Equals(Issue other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(Project, other.Project) && Equals(Tracker, other.Tracker) && Equals(Status, other.Status) && Equals(Priority, other.Priority) && Equals(Author, other.Author) && Equals(Category, other.Category) && string.Equals(Subject, other.Subject) && string.Equals(Description, other.Description) && StartDate.Equals(other.StartDate) && DueDate.Equals(other.DueDate) && DoneRatio.Equals(other.DoneRatio) && PrivateNotes == other.PrivateNotes && EstimatedHours.Equals(other.EstimatedHours) && SpentHours.Equals(other.SpentHours) && Equals(CustomFields, other.CustomFields) && CreatedOn.Equals(other.CreatedOn) && UpdatedOn.Equals(other.UpdatedOn) && ClosedOn.Equals(other.ClosedOn) && string.Equals(Notes, other.Notes) && Equals(AssignedTo, other.AssignedTo) && Equals(ParentIssue, other.ParentIssue) && Equals(FixedVersion, other.FixedVersion) && IsPrivate == other.IsPrivate && TotalSpentHours.Equals(other.TotalSpentHours) && TotalEstimatedHours.Equals(other.TotalEstimatedHours) && Equals(Journals, other.Journals) && Equals(Changesets, other.Changesets) && Equals(Attachments, other.Attachments) && Equals(Relations, other.Relations) && Equals(Children, other.Children) && Equals(Uploads, other.Uploads) && Equals(Watchers, other.Watchers);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Issue) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Project != null ? Project.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Tracker != null ? Tracker.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Status != null ? Status.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Priority != null ? Priority.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Author != null ? Author.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Category != null ? Category.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Subject != null ? Subject.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ StartDate.GetHashCode();
                hashCode = (hashCode * 397) ^ DueDate.GetHashCode();
                hashCode = (hashCode * 397) ^ DoneRatio.GetHashCode();
                hashCode = (hashCode * 397) ^ PrivateNotes.GetHashCode();
                hashCode = (hashCode * 397) ^ EstimatedHours.GetHashCode();
                hashCode = (hashCode * 397) ^ SpentHours.GetHashCode();
                hashCode = (hashCode * 397) ^ (CustomFields != null ? CustomFields.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CreatedOn.GetHashCode();
                hashCode = (hashCode * 397) ^ UpdatedOn.GetHashCode();
                hashCode = (hashCode * 397) ^ ClosedOn.GetHashCode();
                hashCode = (hashCode * 397) ^ (Notes != null ? Notes.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AssignedTo != null ? AssignedTo.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ParentIssue != null ? ParentIssue.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FixedVersion != null ? FixedVersion.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ IsPrivate.GetHashCode();
                hashCode = (hashCode * 397) ^ TotalSpentHours.GetHashCode();
                hashCode = (hashCode * 397) ^ TotalEstimatedHours.GetHashCode();
                hashCode = (hashCode * 397) ^ (Journals != null ? Journals.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Changesets != null ? Changesets.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Attachments != null ? Attachments.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Relations != null ? Relations.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Children != null ? Children.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Uploads != null ? Uploads.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Watchers != null ? Watchers.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}