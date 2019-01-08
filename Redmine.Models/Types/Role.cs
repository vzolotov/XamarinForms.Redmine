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
    /// </summary>
    public class Role : IdentifiableName, IEquatable<Role>
    {
        /// <summary>
        /// Gets or sets the permissions.
        /// </summary>
        /// <value>
        /// The issue relations.
        /// </value>
        public IList<Permission> Permissions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Role other)
        {
            if (other == null) return false;
            return Id == other.Id && Name == other.Name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as Role);
        }

        public override int GetHashCode()
        {
            var hashCode = -1405956071;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<Permission>>.Default.GetHashCode(Permissions);
            return hashCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"[Role: Id={Id}, Name={Name}, Permissions={Permissions}]";
        }
    }
}