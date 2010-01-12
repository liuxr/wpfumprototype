using System;
using System.Windows.Input;
using TreeViewDemo.Source.ViewModel;

namespace TreeViewDemo.Source.Commands {
    public class SearchFamilyTreeCommand : ICommand {
        private readonly GroupsTreeViewModel _groupsTreeViewModel;

        public SearchFamilyTreeCommand(GroupsTreeViewModel groupsTreeViewModel) {
            _groupsTreeViewModel = groupsTreeViewModel;
        }

        #region ICommand Members

        public void Execute(object parameter) {
            _groupsTreeViewModel.PerformSearch();
        }

        public bool CanExecute(object parameter) {
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