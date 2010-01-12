using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BusinessLib.DataAccess;
using BusinessLib.DataModel;

namespace TreeViewDemo.Source.ViewModel {
    public class GroupViewModel : BaseViewModel {
        private readonly ReadOnlyCollection<GroupViewModel> _children;
        private readonly Group _group;
        private readonly GroupViewModel _parent;
        private bool _isExpanded;
        private bool _isSelected;

        public GroupViewModel(Group group, GroupViewModel parent) {
            _group = group;
            _parent = parent;

            _children = new ReadOnlyCollection<GroupViewModel>(
                    (from child in _group.SubGroups select new GroupViewModel(child, this)).ToList()
                    );
        }

        public GroupViewModel(Group group)
                : this(group, null) {
        }

        public bool IsSelected {
            get {
                return _isSelected;
            }
            set {
                if (value != _isSelected) {
                    _isSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }

        public bool IsExpanded {
            get {
                return _isExpanded;
            }
            set {
                if (value != _isExpanded) {
                    _isExpanded = value;
                    OnPropertyChanged("IsExpanded");
                }

                if (_isExpanded && _parent != null) {
                    _parent.IsExpanded = true;
                }
            }
        }

        public string Name {
            get {
                return _group.Name;
            }
        }

        public GroupViewModel Parent {
            get {
                return _parent;
            }
        }

        public IEnumerable<GroupViewModel> Children {
            get {
                return _children;
            }
        }

        public UserViewModel[] GetGroupUsers() {
            var users = FakeDataService.GetGroupUsers(_group);
            return (from user in users select new UserViewModel(user)).ToArray();
        }

        public bool NameContainsText(string text) {
            if (String.IsNullOrEmpty(text) || String.IsNullOrEmpty(Name)) {
                return false;
            }

            return Name.IndexOf(text, StringComparison.InvariantCultureIgnoreCase) > -1;
        }
    }
}