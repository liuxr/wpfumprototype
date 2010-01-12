using System;
using System.Windows;
using System.Windows.Input;
using TreeViewDemo.Source.ViewModel;

namespace TreeViewDemo.Source.Commands {
    public class DeleteUserCommand : ICommand {
        private readonly UserListViewModel _usersListViewModel;

        public DeleteUserCommand(UserListViewModel usersListViewModel) {
            _usersListViewModel = usersListViewModel;
        }

        #region ICommand Members

        public void Execute(object parameter) {
            _usersListViewModel.PerformDelete();
        }

        public bool CanExecute(object parameter) {
            // Always can execute
            return true;
        }

        public event EventHandler CanExecuteChanged {
            add {
            }
            remove {
            }
        }

        #endregion
    }
}