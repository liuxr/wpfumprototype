using System;
using System.Collections.Generic;
using BusinessLib.DataAccess;

namespace BusinessLib.DataModel {
    public class User {
        private readonly IList<Group> _groupMembership = new List<Group>();

        public User(string userName) {
            UserName = userName;
        }

        public IList<Group> GroupMembership {
            get {
                return _groupMembership;
            }
        }

        //General user information
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public bool EnableStdAuthentication { get; set; }
        public string Password { get; set; }
        public bool ChangePassword { get; set; }
        public string PreferredLanguage { get; set; }
        public string Email { get; set; }
        public DateTime LastLogonDate { get; set; }
        public LockStatus LockStatus { get; set; }
        public int InvalidAuthCount { get; set; }

        //Windows Authentication tab
        public bool EnableWindowsAuth { get; set; }
        public string WindowsAccount { get; set; }

        //Sun5 plugin tab
        public string OperatorCode { get; set; }
        public string LookupCode { get; set; }
        public string ShortHeading { get; set; }
        public string DefaultBusinessUnit {get;set;}
        public string Sun5Language { get; set; }
        public string DefaultLedger { get; set; }
        public string TemporaryWorkFolder { get; set; }

        //Sun5 Authorization tab
        public bool EnableSun5Authorizer { get; set; }
        public string AuthorizationPassword { get; set; }
        public int InvalidAuthorizationCount { get; set; }

        //Directory Serivce tab
        public bool EnableDirectoryAuth { get; set; }
        public string DirectoryServiceAccount { get; set; }


        public string GetMembershipString() {
            string result = "";
            foreach (Group group in _groupMembership) {
                result += group.Name + " ,";
            }
            result = result.TrimEnd(',');
            return result;
        }

        public void RemoveGroupMembership(string name) {
            Group target = null;
            foreach (Group group in _groupMembership) {
                if (group.Name == name) {
                    target = group;
                    break;
                }
            }
            if (target != null) {
                _groupMembership.Remove(target);
            }
        }

        public void AddGroupMembership(string name) {
            if(!GetMembershipString().Contains(name)) {
                Group[] groups = FakeDataService.GetGroups(name);
                if (groups != null && groups.Length == 1) {
                    _groupMembership.Add(groups[0]);
                }
            }
        }
    }
}