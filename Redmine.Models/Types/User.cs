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
    /// Availability 1.1
    /// </summary>
    public class User : Identifiable<User>, IEquatable<User>
    {
        /// <summary>
        /// Gets or sets the user login.
        /// </summary>
        /// <value>The login.</value>
        public String Login { get; set; }

        /// <summary>
        /// Gets or sets the user password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public String FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public String LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public String Email { get; set; }

        /// <summary>
        /// Gets or sets the authentication mode id.
        /// </summary>
        /// <value>
        /// The authentication mode id.
        /// </value>
        public Int32? AuthenticationModeId { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        /// <value>The created on.</value>
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the last login on.
        /// </summary>
        /// <value>The last login on.</value>
        public DateTime? LastLoginOn { get; set; }

        /// <summary>
        /// Gets the API key of the user, visible for admins and for yourself (added in 2.3.0)
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets the status of the user, visible for admins only (added in 2.4.0)
        /// </summary>
        public UserStatus Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool MustChangePassword { get; set; }

        /// <summary>
        /// Gets or sets the custom fields.
        /// </summary>
        /// <value>The custom fields.</value>
        public List<IssueCustomField> CustomFields { get; set; }

        /// <summary>
        /// Gets or sets the memberships.
        /// </summary>
        /// <value>
        /// The memberships.
        /// </value>
        public List<Membership> Memberships { get; set; }

        /// <summary>
        /// Gets or sets the user's groups.
        /// </summary>
        /// <value>
        /// The groups.
        /// </value>
        public List<UserGroup> Groups { get; set; }

        /// <summary>
        /// Gets or sets the user's mail_notification.
        /// </summary>
        /// <value>
        /// only_my_events, only_assigned, [...]
        /// </value>
        public string MailNotification { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[User: {14}, Login={0}, Password={1}, FirstName={2}, LastName={3}, Email={4}, EmailNotification={5}, AuthenticationModeId={6}, CreatedOn={7}, LastLoginOn={8}, ApiKey={9}, Status={10}, MustChangePassword={11}, CustomFields={12}, Memberships={13}, Groups={14}]",
                Login, Password, FirstName, LastName, Email, MailNotification, AuthenticationModeId, CreatedOn, LastLoginOn, ApiKey, Status, MustChangePassword, CustomFields, Memberships, Groups, base.ToString());
        }

        public bool Equals(User other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && string.Equals(Login, other.Login) && string.Equals(Password, other.Password) && string.Equals(FirstName, other.FirstName) && string.Equals(LastName, other.LastName) && string.Equals(Email, other.Email) && AuthenticationModeId == other.AuthenticationModeId && CreatedOn.Equals(other.CreatedOn) && LastLoginOn.Equals(other.LastLoginOn) && string.Equals(ApiKey, other.ApiKey) && Status == other.Status && MustChangePassword == other.MustChangePassword && Equals(CustomFields, other.CustomFields) && Equals(Memberships, other.Memberships) && Equals(Groups, other.Groups) && string.Equals(MailNotification, other.MailNotification);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Login != null ? Login.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Password != null ? Password.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Email != null ? Email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ AuthenticationModeId.GetHashCode();
                hashCode = (hashCode * 397) ^ CreatedOn.GetHashCode();
                hashCode = (hashCode * 397) ^ LastLoginOn.GetHashCode();
                hashCode = (hashCode * 397) ^ (ApiKey != null ? ApiKey.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) Status;
                hashCode = (hashCode * 397) ^ MustChangePassword.GetHashCode();
                hashCode = (hashCode * 397) ^ (CustomFields != null ? CustomFields.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Memberships != null ? Memberships.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Groups != null ? Groups.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (MailNotification != null ? MailNotification.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}