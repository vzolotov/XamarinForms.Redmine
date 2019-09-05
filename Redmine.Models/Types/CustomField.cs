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
    public class CustomField : IdentifiableName, IEquatable<CustomField>
    {
        /// <summary>
        /// 
        /// </summary>
        public string CustomizedType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FieldFormat { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Regexp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? MinLength { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? MaxLength { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsFilter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Searchable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Multiple { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<CustomFieldPossibleValue> PossibleValues { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<TrackerCustomField> Trackers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<CustomFieldRole> Roles { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(CustomField other)
        {
            if (other == null) return false;

            return Id == other.Id
                && IsFilter == other.IsFilter
                && IsRequired == other.IsRequired
                && Multiple == other.Multiple
                && Searchable == other.Searchable
                && Visible == other.Visible
                && CustomizedType.Equals(other.CustomizedType)
                && DefaultValue.Equals(other.DefaultValue)
                && FieldFormat.Equals(other.FieldFormat)
                && MaxLength == other.MaxLength
                && MinLength == other.MinLength
                && Name.Equals(other.Name)
                && Regexp.Equals(other.Regexp)
                && PossibleValues.Equals(other.PossibleValues)
                && Roles.Equals(other.Roles)
                && Trackers.Equals(other.Trackers);
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
            return Equals(obj as CustomField);
        }

        public override int GetHashCode()
        {
            var hashCode = -1067145431;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustomizedType);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FieldFormat);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Regexp);
            hashCode = hashCode * -1521134295 + EqualityComparer<int?>.Default.GetHashCode(MinLength);
            hashCode = hashCode * -1521134295 + EqualityComparer<int?>.Default.GetHashCode(MaxLength);
            hashCode = hashCode * -1521134295 + IsRequired.GetHashCode();
            hashCode = hashCode * -1521134295 + IsFilter.GetHashCode();
            hashCode = hashCode * -1521134295 + Searchable.GetHashCode();
            hashCode = hashCode * -1521134295 + Multiple.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DefaultValue);
            hashCode = hashCode * -1521134295 + Visible.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<CustomFieldPossibleValue>>.Default.GetHashCode(PossibleValues);
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<TrackerCustomField>>.Default.GetHashCode(Trackers);
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<CustomFieldRole>>.Default.GetHashCode(Roles);
            return hashCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString ()
		{
			return
                $"[CustomField: Id={Id}, Name={Name}, CustomizedType={CustomizedType}, FieldFormat={FieldFormat}, Regexp={Regexp}, MinLength={MinLength}, MaxLength={MaxLength}, IsRequired={IsRequired}, IsFilter={IsFilter}, Searchable={Searchable}, Multiple={Multiple}, DefaultValue={DefaultValue}, Visible={Visible}, PossibleValues={PossibleValues}, Trackers={Trackers}, Roles={Roles}]";
		}
    }
}