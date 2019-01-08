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
    /// Availability 1.3
    /// </summary>
    public class Version : IdentifiableName, IEquatable<Version>
    {
        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        /// <value>The project.</value>
        public IdentifiableName Project { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public String Description { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public VersionStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the due date.
        /// </summary>
        /// <value>The due date.</value>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Gets or sets the sharing.
        /// </summary>
        /// <value>The sharing.</value>
        public VersionSharing Sharing { get; set; }

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
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Version other)
        {
            if (other == null) return false;
            return (Id == other.Id && Name == other.Name
                && Project == other.Project
                && Description == other.Description
                && Status == other.Status
                && DueDate == other.DueDate
                && Sharing == other.Sharing
                && CreatedOn == other.CreatedOn
                && UpdatedOn == other.UpdatedOn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[Version: {8}, Project={0}, Description={1}, Status={2}, DueDate={3}, Sharing={4}, CreatedOn={5}, UpdatedOn={6}, CustomFields={7}]",
                Project, Description, Status, DueDate, Sharing, CreatedOn, UpdatedOn, CustomFields, base.ToString());
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum VersionSharing
    {
        /// <summary>
        /// 
        /// </summary>
        none = 1,
        /// <summary>
        /// 
        /// </summary>
        descendants,
        /// <summary>
        /// 
        /// </summary>
        hierarchy,
        /// <summary>
        /// 
        /// </summary>
        tree,
        /// <summary>
        /// 
        /// </summary>
        system
    }

    /// <summary>
    /// 
    /// </summary>
    public enum VersionStatus
    {
        /// <summary>
        /// 
        /// </summary>
        open = 1,
        /// <summary>
        /// 
        /// </summary>
        locked,
        /// <summary>
        /// 
        /// </summary>
        closed
    }
}