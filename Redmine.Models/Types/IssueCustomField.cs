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
    /// 
    /// </summary>
    public class IssueCustomField : IdentifiableName, IEquatable<IssueCustomField>
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public IList<CustomFieldValue> Values { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Multiple { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[IssueCustomField: {2} Values={0}, Multiple={1}]", Values, Multiple, base.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string GetValue(object item)
        {
            return ((CustomFieldValue)item).Info;
        }

        public bool Equals(IssueCustomField other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(Values, other.Values) && Multiple == other.Multiple;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IssueCustomField) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Values != null ? Values.GetHashCode() : 0) * 397) ^ Multiple.GetHashCode();
            }
        }
    }
}