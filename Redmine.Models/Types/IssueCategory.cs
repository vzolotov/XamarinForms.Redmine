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
    public class IssueCategory : Identifiable<IssueCategory>, IEquatable<IssueCategory>
    {
        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        /// <value>
        /// The project.
        /// </value>
        public IdentifiableName Project { get; set; }

        /// <summary>
        /// Gets or sets the asign to.
        /// </summary>
        /// <value>
        /// The asign to.
        /// </value>
        public IdentifiableName AsignTo { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(IssueCategory other)
        {
            if (other == null) return false;
            return (Id == other.Id && Project == other.Project && AsignTo == other.AsignTo && Name == other.Name);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[IssueCategory: {3}, Project={0}, AsignTo={1}, Name={2}]", Project, AsignTo, Name, base.ToString());
        }
    }
}