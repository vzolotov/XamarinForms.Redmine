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
    /// Only the roles can be updated, the project and the user of a membership are read-only.
    /// </summary>
    public class Membership : Identifiable<Membership>, IEquatable<Membership>
    {
        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        /// <value>The project.</value>
        public IdentifiableName Project { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public List<MembershipRole> Roles { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[Membership: {2}, Project={0}, Roles={1}]", Project, Roles, base.ToString());
        }

        public bool Equals(Membership other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(Project, other.Project) && Equals(Roles, other.Roles);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Membership) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Project != null ? Project.GetHashCode() : 0) * 397) ^ (Roles != null ? Roles.GetHashCode() : 0);
            }
        }
    }
}