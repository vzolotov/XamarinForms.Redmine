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
    public class IssueRelation : Identifiable<IssueRelation>, IEquatable<IssueRelation>
    {
        /// <summary>
        /// Gets or sets the issue id.
        /// </summary>
        /// <value>The issue id.</value>
        public int IssueId { get; set; }

        /// <summary>
        /// Gets or sets the related issue id.
        /// </summary>
        /// <value>The issue to id.</value>
        public int IssueToId { get; set; }

        /// <summary>
        /// Gets or sets the type of relation.
        /// </summary>
        /// <value>The type.</value>
        public IssueRelationType Type { get; set; }

        /// <summary>
        /// Gets or sets the delay for a "precedes" or "follows" relation.
        /// </summary>
        /// <value>The delay.</value>
        public int? Delay { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(IssueRelation other)
        {
            if (other == null) return false;
            return (Id == other.Id && IssueId == other.IssueId && IssueToId == other.IssueToId && Type == other.Type && Delay == other.Delay);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[IssueRelation: {4}, IssueId={0}, IssueToId={1}, Type={2}, Delay={3}]", IssueId, IssueToId, Type, Delay, base.ToString());
        }
    }
}