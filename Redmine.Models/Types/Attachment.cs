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
    /// Availability 1.3
    /// </summary>
    public class Attachment : Identifiable<Attachment>, IEquatable<Attachment>
    {
        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public String FileName { get; set; }

        /// <summary>
        /// Gets or sets the size of the file.
        /// </summary>
        /// <value>The size of the file.</value>
        public int FileSize { get; set; }

        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        /// <value>The type of the content.</value>
        public String ContentType { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public String Description { get; set; }

        /// <summary>
        /// Gets or sets the content URL.
        /// </summary>
        /// <value>The content URL.</value>]
        public String ContentUrl { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>The author.</value>
        public IdentifiableName Author { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        /// <value>The created on.</value>
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public XmlSchema GetSchema() { return null; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Attachment other)
        {
            if (other == null) return false;
            return (Id == other.Id
                && FileName == other.FileName
                && FileSize == other.FileSize
                && ContentType == other.ContentType
                && Author == other.Author
                && CreatedOn == other.CreatedOn
                && Description == other.Description
                && ContentUrl == other.ContentUrl);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[Attachment: {7}, FileName={0}, FileSize={1}, ContentType={2}, Description={3}, ContentUrl={4}, Author={5}, CreatedOn={6}]",
                FileName, FileSize, ContentType, Description, ContentUrl, Author, CreatedOn, base.ToString());
        }

        public override int GetHashCode()
        {
            var hashCode = 317608122;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FileName);
            hashCode = hashCode * -1521134295 + FileSize.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ContentType);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ContentUrl);
            hashCode = hashCode * -1521134295 + EqualityComparer<IdentifiableName>.Default.GetHashCode(Author);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTime?>.Default.GetHashCode(CreatedOn);
            return hashCode;
        }
    }
}