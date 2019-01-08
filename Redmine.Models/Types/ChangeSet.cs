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
using System.Xml;
using System.Xml.Schema;

namespace Redmine.Models.Types
{
    /// <summary>
    /// 
    /// </summary>
    public class ChangeSet : IEquatable<ChangeSet>
    {
        /// <summary>
        /// 
        /// </summary>
        public int Revision { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IdentifiableName User { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? CommittedOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public XmlSchema GetSchema() { return null; }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        public void WriteXml(XmlWriter writer) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(ChangeSet other)
        {
            if (other == null) return false;

            return Revision == other.Revision
                && User == other.User
                && Comments == other.Comments
                && CommittedOn == other.CommittedOn;
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
            return Equals(obj as ChangeSet);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Revision: {Revision}, User: '{User}', CommitedOn: {CommittedOn}, Comments: '{Comments}'";
        }

        public override int GetHashCode()
        {
            var hashCode = -1712107267;
            hashCode = hashCode * -1521134295 + Revision.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<IdentifiableName>.Default.GetHashCode(User);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Comments);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTime?>.Default.GetHashCode(CommittedOn);
            return hashCode;
        }
    }
}