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

namespace Redmine.Models.Types
{
    /// <summary>
    /// 
    /// </summary>
    public class IdentifiableName : Identifiable<IdentifiableName>,  IEquatable<IdentifiableName>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public String Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"[IdentifiableName: Id={Id}, Name={Name}]";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(IdentifiableName other)
        {
            if (other == null) return false;
            return (Id == other.Id && Name == other.Name);
        }
    }
}