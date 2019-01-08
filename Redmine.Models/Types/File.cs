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
using System.Xml.Schema;

namespace Redmine.Models.Types
{
    /// <summary>
    /// 
    /// </summary>
    public class File : Identifiable<File>, IEquatable<File>
    {

        /// <summary>
        /// 
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Filesize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ContentUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IdentifiableName Author { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IdentifiableName Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Digest { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Downloads { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Token { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(File other)
        {
            if (other == null) return false;
            return (Id == other.Id 
                && Filename == other.Filename 
                && Filesize == other.Filesize 
                && Description == other.Description
                && ContentType == other.ContentType 
                && ContentUrl == other.ContentUrl
                && Author ==other.Author
                && CreatedOn == other.CreatedOn
                && Version == other.Version
                && Digest == other.Digest
                && Downloads == other.Downloads
                && Token == other.Token
                );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"[File: Id={Id}, Name={Filename}]";
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
            return Equals(obj as File);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        public override int GetHashCode()
        {
            var hashCode = -639410138;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Filename);
            hashCode = hashCode * -1521134295 + Filesize.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ContentType);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ContentUrl);
            hashCode = hashCode * -1521134295 + EqualityComparer<IdentifiableName>.Default.GetHashCode(Author);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTime?>.Default.GetHashCode(CreatedOn);
            hashCode = hashCode * -1521134295 + EqualityComparer<IdentifiableName>.Default.GetHashCode(Version);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Digest);
            hashCode = hashCode * -1521134295 + Downloads.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Token);
            return hashCode;
        }
    }
}