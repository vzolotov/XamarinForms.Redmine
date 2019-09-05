﻿/*
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
    /// Support for adding attachments through the REST API is added in Redmine 1.4.0.
    /// </summary>
    public class Upload : IEquatable<Upload>
    {
        /// <summary>
        /// Gets or sets the uploaded token.
        /// </summary>
        /// <value>The name of the file.</value>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// Maximum allowed file size (1024000).
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the file description. (Undocumented feature)
        /// </summary>
        /// <value>The file descroütopm.</value>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public XmlSchema GetSchema() { return null; }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public bool Equals(Upload other)
        {
            return other != null
                && Token.Equals(other.Token)
                && FileName.Equals(other.FileName)
                && Description.Equals(other.Description)
                && ContentType.Equals(other.ContentType);
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
            return Equals(obj as Upload);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return
                $"[Upload: Token={Token}, FileName={FileName}, ContentType={ContentType}, Description={Description}]";
        }

        public override int GetHashCode()
        {
            var hashCode = -1217752011;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Token);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FileName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ContentType);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            return hashCode;
        }
    }
}