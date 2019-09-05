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
    /// Availability 2.2
    /// </summary>
    public class WikiPage : Identifiable<WikiPage>, IEquatable<WikiPage>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IdentifiableName Author { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        /// <value>The created on.</value>
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the updated on.
        /// </summary>
        /// <value>The updated on.</value>
        public DateTime? UpdatedOn { get; set; }

        /// <summary>
        /// Gets or sets the attachments.
        /// </summary>
        /// <value>
        /// The attachments.
        /// </value>
        public IList<Attachment> Attachments { get; set; }

        /// <summary>
        /// Sets the uploads.
        /// </summary>
        /// <value>
        /// The uploads.
        /// </value>
        /// <remarks>Availability starting with redmine version 3.3</remarks>
        public IList<Upload> Uploads { get; set; }

        #region Implementation of IEquatable<WikiPage>

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(WikiPage other)
        {
            if (other == null) return false;

            return Id == other.Id
                   && Title == other.Title
                   && Text == other.Text
                   && Comments == other.Comments
                   && Version == other.Version
                   && Author == other.Author
                   && CreatedOn == other.CreatedOn
                   && UpdatedOn == other.UpdatedOn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[WikiPage: {8}, Title={0}, Text={1}, Comments={2}, Version={3}, Author={4}, CreatedOn={5}, UpdatedOn={6}, Attachments={7}]",
                Title, Text, Comments, Version, Author, CreatedOn, UpdatedOn, Attachments, base.ToString());
        }

        #endregion
    }
}