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
    /// Availability 2.1
    /// </summary>
    public class Group : IdentifiableName, IEquatable<Group>
    {
        /// <summary>
        /// Represents the group's users.
        /// </summary>
        public List<GroupUser> Users { get; set; }

        /// <summary>
        /// Gets or sets the custom fields.
        /// </summary>
        /// <value>The custom fields.</value>
        public IList<IssueCustomField> CustomFields { get; set; }

        /// <summary>
        /// Gets or sets the custom fields.
        /// </summary>
        /// <value>The custom fields.</value>
        public IList<Membership> Memberships { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return
                $"[Group: Id={Id}, Name={Name}, Users={Users}, CustomFields={CustomFields}, Memberships={Memberships}]";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gu"></param>
        /// <returns></returns>
        public int GetGroupUserId(object gu)
        {
            return ((GroupUser)gu).Id;
        }

        public bool Equals(Group other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(Users, other.Users) && Equals(CustomFields, other.CustomFields) && Equals(Memberships, other.Memberships);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Group) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (Users != null ? Users.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CustomFields != null ? CustomFields.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Memberships != null ? Memberships.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}