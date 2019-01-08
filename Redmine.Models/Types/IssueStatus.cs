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
    /// Availability 1.3
    /// </summary>
    public class IssueStatus : IdentifiableName, IEquatable<IssueStatus>
    {
        /// <summary>
        /// Gets or sets a value indicating whether IssueStatus is default.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if IssueStatus is default; otherwise, <c>false</c>.
        /// </value>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IssueStatus is closed.
        /// </summary>
        /// <value><c>true</c> if IssueStatus is closed; otherwise, <c>false</c>.</value>
        public bool IsClosed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(IssueStatus other)
        {
            if (other == null) return false;
            return (Id == other.Id && Name == other.Name && IsClosed == other.IsClosed && IsDefault == other.IsDefault);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[IssueStatus: {2}, IsDefault={0}, IsClosed={1}]", IsDefault, IsClosed, base.ToString());
        }
    }
}