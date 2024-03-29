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

namespace Redmine.Models.Types
{
    /// <summary>
    /// 
    /// </summary>
    public enum IssueRelationType
    {
        /// <summary>
        /// 
        /// </summary>
        relates = 1,
        /// <summary>
        /// 
        /// </summary>
        duplicates,
        /// <summary>
        /// 
        /// </summary>
        duplicated,
        /// <summary>
        /// 
        /// </summary>
        blocks,
        /// <summary>
        /// 
        /// </summary>
        blocked,
        /// <summary>
        /// 
        /// </summary>
        precedes,
        /// <summary>
        /// 
        /// </summary>
        follows,
        /// <summary>
        /// 
        /// </summary>
        copied_to,
        /// <summary>
        /// 
        /// </summary>
        copied_from
    }
}