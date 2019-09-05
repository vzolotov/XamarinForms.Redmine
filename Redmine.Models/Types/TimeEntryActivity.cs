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

namespace Redmine.Models.Types
{
    /// <summary>
    /// Availability 2.2
    /// </summary>
    public class TimeEntryActivity : IdentifiableName, IEquatable<TimeEntryActivity>
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsDefault { get; set; }

        #region Implementation of IEquatable<TimeEntryActivity>

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(TimeEntryActivity other)
        {
            if (other == null) return false;

            return Id == other.Id && Name == other.Name && IsDefault == other.IsDefault;
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
            return Equals(obj as TimeEntryActivity);
        }

        public override int GetHashCode()
        {
            var hashCode = 725765796;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + IsDefault.GetHashCode();
            return hashCode;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"[TimeEntryActivity: Id={Id}, Name={Name}, IsDefault={IsDefault}]";
        }
    }
}