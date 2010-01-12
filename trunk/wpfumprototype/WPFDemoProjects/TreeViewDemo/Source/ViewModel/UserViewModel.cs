using System;
using BusinessLib.DataAccess;
using BusinessLib.DataModel;

namespace TreeViewDemo.Source.ViewModel {
    public class UserViewModel : BaseViewModel {
        private readonly User _user;

        public UserViewModel()
                : this(null) {
        }

        public UserViewModel(User user) {
            if (user == null) {
                user = new User("<User Name>");
            }
            _user = user;
        }

        public User User {
            get {
                return _user;
            }
        }

        public string UserName {
            get {
                return _user.UserName;
            }
            set {
                if (_user.UserName != value) {
                    _user.UserName = value;
                    OnPropertyChanged("UserName");
                }
            }
        }

        public string Description {
            get {
                return _user.Description;
            }
            set {
                if (_user.Description != value) {
                    _user.Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public string Membership {
            get {
                return _user.GetMembershipString();
            }
        }

        public void RemoveGroupMembership(GroupViewModel model) {
            _user.RemoveGroupMembership(model.Name);
            OnPropertyChanged("Membership");
        }

        public void AddGroupMembership(GroupViewModel model) {
            _user.AddGroupMembership(model.Name);
            OnPropertyChanged("Membership");
        }

        public void SubmitChanges() {
            FakeDataService.UpdateUser(_user);
        }

        public UserViewModel Clone() {
            var clone = new UserViewModel();
            clone.UserName = UserName;
            clone.Description = Description;
            foreach (Group group in _user.GroupMembership) {
                clone.AddGroupMembership(new GroupViewModel(group));
            }
            return clone;
        }

        public void RestoreState(UserViewModel model) {
            if (model != null) {
                UserName = model.UserName;
                Description = model.Description;
                _user.GroupMembership.Clear();
                foreach (Group group in model._user.GroupMembership) {
                    AddGroupMembership(new GroupViewModel(group));
                }
            }
        }

        public void Delete() {
            FakeDataService.DeleteUser(_user);
        }
    }
}