using System;
using System.Collections.Generic;

namespace BusinessLib.DataModel {
    public class Group {
        private readonly List<Group> _subGroups = new List<Group>();
        private readonly List<User> _users = new List<User>();

        public IList<Group> SubGroups {
            get {
                return _subGroups;
            }
        }

        public string Name { get; set; }
    }
}