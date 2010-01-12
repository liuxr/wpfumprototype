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

        public string UserName { get; set; }
        public string Description { get; set; }

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