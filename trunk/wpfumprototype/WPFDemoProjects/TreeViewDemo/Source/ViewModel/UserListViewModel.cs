using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using BusinessLib.DataModel;
using TreeViewDemo.Source.Commands;

namespace TreeViewDemo.Source.ViewModel {
    public class UserListViewModel : BaseViewModel {
        private readonly DeleteUserCommand _deleteUserCommand;
        private readonly ObservableCollection<UserViewModelNew> _users;
        private UserViewModelNew _currentUser;
        //        private readonly SearchFamilyTreeCommand _searchCommand;

        public UserListViewModel() {
            _deleteUserCommand = new DeleteUserCommand(this);
        }

        public UserListViewModel(params User[] roots)
                : this() {
            _users = new ObservableCollection<UserViewModelNew>(
                    (from temp in roots select new UserViewModelNew(temp)).ToList());
        }

        public UserListViewModel(params UserViewModelNew[] roots)
                : this() {
            _users = new ObservableCollection<UserViewModelNew>(
                    (from temp in roots select temp).ToList());
        }

        public ObservableCollection<UserViewModelNew> Users {
            get {
                return _users;
            }
        }

        public DeleteUserCommand DeleteUserCommand {
            get {
                return _deleteUserCommand;
            }
        }

        public UserViewModelNew CurrentUser {
            get {
                return _currentUser;
            }
            set {
                if (value == _currentUser) {
                    return;
                }
                _currentUser = value;
                OnPropertyChanged("CurrentUser");
            }
        }

        public void PerformDelete() {
            if (CurrentUser != null) {
                if (MessageBoxResult.Yes ==
                    MessageBox.Show("Do you really want to delete user '" + CurrentUser.UserName + "'?",
                                    "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Exclamation)
                        ) {
                    CurrentUser.Delete();

                    // Notify UI to perform refresh
                    _users.Remove(CurrentUser);

                    // Default selection after deletion
                    if(_users.Count > 0) {
                        CurrentUser = _users[0];
                    }
                }
            }
        }
    }
}