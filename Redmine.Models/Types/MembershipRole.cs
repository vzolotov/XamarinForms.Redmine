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
    /// 
    /// </summary>
    public class MembershipRole : IdentifiableName, IEquatable<MembershipRole>
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MembershipRole"/> is inherited.
        /// </summary>
        /// <value>
        ///   <c>true</c> if inherited; otherwise, <c>false</c>.
        /// </value>
        public bool Inherited { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(MembershipRole other)
        {
            if (other == null) return false;
            return Id == other.Id && Name == other.Name && Inherited == other.Inherited;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[MembershipRole: {1}, Inherited={0}]", Inherited, base.ToString());
        }
    }
}