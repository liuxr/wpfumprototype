using BusinessLib.DataAccess;
using BusinessLib.DataModel;

namespace TreeViewDemo.Source.ViewModel {
    public class GroupsPageViewModel : BaseViewModel {
        private readonly GroupsTreeViewModel _groupsTreeViewModel;
        private GroupViewModel _currentGroup;

        public GroupsPageViewModel() {
            // Get raw group tree data from a database
            Group[] rootGroups = FakeDataService.GetGroupsTree();

            // Create UI-friendly wrappers around the raw data objects(i.e. the view-model).
            _groupsTreeViewModel = new GroupsTreeViewModel(rootGroups);
        }

        public GroupsTreeViewModel GroupsTreeViewModel {
            get {
                return _groupsTreeViewModel;
            }
        }

        public GroupViewModel CurrentGroup {
            get {
                return _currentGroup;
            }
            set {
                if (value == _currentGroup) {
                    return;
                }
                _currentGroup = value;
                OnPropertyChanged("CurrentGroup");
            }
        }
    }
}