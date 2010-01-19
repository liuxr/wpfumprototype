using System;
using System.Collections.Generic;
using BusinessLib.DataModel;

namespace BusinessLib.DataAccess {
    public class FakeDataService {
        private static readonly Dictionary<string, Group> GroupsDict = new Dictionary<string, Group>();
        private static readonly Dictionary<string, User> UsersDict = new Dictionary<string, User>();

        static FakeDataService() {
            SetupFakeGroups();
            SetupFakeUsers();
        }

        #region CRUD Users

        public static void UpdateUser(User user) {
            //Check existence
            if (!UsersDict.ContainsKey(user.UserName)) {
                // Add it then
                UsersDict.Add(user.UserName, user);
            } else {
                //Update
                UsersDict[user.UserName] = user;
            }
        }

        public static void DeleteUser(User user) {
            //Check existence
            if (!UsersDict.ContainsKey(user.UserName)) {
                // Log and show
                return;
            }
            //Perform delete
            UsersDict.Remove(user.UserName);
        }

        #endregion

        #region CRUD Group

        public static void AddGroup(Group newGroup) {
            //Check dup
            if (GroupsDict.ContainsKey(newGroup.Name)) {
                return;
            }
            //Perform add
            GroupsDict.Add(newGroup.Name, newGroup);
        }

        public static void UpdateGroup(Group group) {
            //Check existence
            if (!GroupsDict.ContainsKey(group.Name)) {
                // Log and show
                return;
            }
            //Perform update
            GroupsDict[group.Name] = group;
        }

        public static void RemvoeGroup(Group group) {
            //Check exitence
            if (!GroupsDict.ContainsKey(group.Name)) {
                // Log and show
                return;
            }
            //Perform Hide
            GroupsDict.Remove(group.Name);
        }

        #endregion

        private static void SetupFakeUsers() {
            var users = new[]
                            {
                                new User("admin")
                                    {
                                        Description =
                                            "SunSystems administrator which can manage the users and groups",
                                        GroupMembership =
                                            {
                                                GroupsDict["SunSystems 5 User"],
                                                GroupsDict["PK1"],
                                                GroupsDict["SunSystems Administrator"]
                                            },
                                        FullName = "System Administrator",
                                        Title = "",
                                        PreferredLanguage = PreferredLanguage.Instance.SupportedLanguages[0],
                                        LastLogonDate = DateTime.Today,
                                        LockStatus = LockStatus.Unlocked,

                                        },
                                    new User("GGE")
                                        {
                                                Description = "Finance Manager",
                                                GroupMembership =
                                                        { GroupsDict["SunSystems 5 User"], GroupsDict["AATOP"] }
                                        },
                                    new User("KKE")
                                        {
                                                Description = "Accounts Supervisor",
                                                GroupMembership =
                                                        { GroupsDict["SunSystems 5 User"], GroupsDict["ABMED"] }
                                        },
                                    new User("PK1")
                                        {
                                                Description = "PK1 Menu User 1",
                                                GroupMembership =
                                                        {
                                                                GroupsDict["SunSystems 5 User"],
                                                                GroupsDict["PK1"]
                                                        }
                                        },
                                    new User("PK2")
                                        {
                                                Description = "PK1 Menu User 2",
                                                GroupMembership =
                                                        {
                                                                GroupsDict["SunSystems 5 User"],
                                                                GroupsDict["PK2"]
                                                        }
                                        },
                                    new User("PK3")
                                        {
                                                Description = "Some Fool",
                                                GroupMembership =
                                                        {
                                                                GroupsDict["SunSystems 5 User"],
                                                                GroupsDict["PK1"]
                                                        }
                                        },
                                    new User("SSM")
                                        {
                                                Description = "Accounts Clerk",
                                                GroupMembership =
                                                        {
                                                                GroupsDict["SunSystems 5 User"],
                                                                GroupsDict["BBLOW"]
                                                        }
                                        },
                            };
            foreach (User user in users) {
//                AddUser(user);
                UsersDict[user.UserName] = user;
            }
        }

        public static Group[] GetGroupsTree() {
            return new[]
                       {
                               GroupsDict["Report Server Users"],
                               GroupsDict["SunSystems 5 User"],
                               GroupsDict["SunSystems Administrator"],
                               GroupsDict["SunSystems Connect"],
                       };
        }

        public static User[] GetUsers() {
            return new List<User>(UsersDict.Values).ToArray();
        }

        private static void SetupFakeGroups() {
            var names = new[]
                            {
                                    "Report Server Users",
                                    "SunSystems 5 User",
                                    "AATOP",
                                    "ABMED",
                                    "BBLOW",
                                    "PK1",
                                    "PK2",
                                    "SunSystems Administrator",
                                    "SunSystems Connect",
                                    "Designers",
                                    "Power Users",
                                    "Users",
                            };
            foreach (string name in names) {
                AddGroup(new Group { Name = name });
                //GroupsDict.Add(name, new Group { Name = name });
            }
            GroupsDict["SunSystems 5 User"].SubGroups.Add(GroupsDict["AATOP"]);
            GroupsDict["SunSystems 5 User"].SubGroups.Add(GroupsDict["ABMED"]);
            GroupsDict["SunSystems 5 User"].SubGroups.Add(GroupsDict["BBLOW"]);
            GroupsDict["SunSystems 5 User"].SubGroups.Add(GroupsDict["PK1"]);
            GroupsDict["SunSystems 5 User"].SubGroups.Add(GroupsDict["PK2"]);
            GroupsDict["SunSystems Connect"].SubGroups.Add(GroupsDict["Designers"]);
            GroupsDict["SunSystems Connect"].SubGroups.Add(GroupsDict["Power Users"]);
            GroupsDict["SunSystems Connect"].SubGroups.Add(GroupsDict["Users"]);
        }

        public static User[] GetGroupUsers(Group group) {
            var users = new List<User>();
            foreach (User user in UsersDict.Values) {
                if (user.GroupMembership.Contains(group)) {
                    users.Add(user);
                }
            }
            return users.ToArray();
        }

        public static Group[] GetGroups(params string[] strings) {
            var groups = new List<Group>();
            foreach (string groupName in strings) {
                if (GroupsDict.ContainsKey(groupName.Trim())) {
                    groups.Add(GroupsDict[groupName.Trim()]);
                }
            }
            return groups.ToArray();
        }
    }
}