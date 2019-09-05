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
    /// Availability 1.4
    /// POST - Adds a project member.
    /// GET - Returns the membership of given :id.
    /// PUT - Updates the membership of given :id. Only the roles can be updated, the project and the user of a membership are read-only.
    /// DELETE - Deletes a memberships. Memberships inherited from a group membership can not be deleted. You must delete the group membership.
    /// </summary>
    public class ProjectMembership : Identifiable<ProjectMembership>, IEquatable<ProjectMembership>
    {
        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        /// <value>The project.</value>
        public IdentifiableName Project { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public IdentifiableName User { get; set; }

        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        /// <value>
        /// The group.
        /// </value>
        public IdentifiableName Group { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public List<MembershipRole> Roles { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(ProjectMembership other)
        {
            if (other == null) return false;
            return (Id == other.Id
                && Project.Equals(other.Project)
                && (User != null ? User.Equals(other.User) : other.User == null)
                && (Group != null ? Group.Equals(other.Group) : other.Group == null));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[ProjectMembership: {4}, Project={0}, User={1}, Group={2}, Roles={3}]", Project, User, Group, Roles, base.ToString());
        }
    }
}