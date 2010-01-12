using System.Windows;
using System.Windows.Controls;
using TreeViewDemo.Source.ViewModel;

namespace TreeViewDemo.Source.View {
    /// <summary>
    /// Interaction logic for GroupDetailView.xaml
    /// </summary>
    public partial class GroupDetailView : UserControl {
        private UserListViewModel _userListViewModel;

        public GroupDetailView() {
            InitializeComponent();
            DataContextChanged += GroupDetailView_DataContextChanged;
        }

        private void GroupDetailView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e) {
            var model = DataContext as GroupViewModel;
            if (model != null) {
                _userListViewModel = new UserListViewModel(model.GetGroupUsers());
                _usersListView.DataContext = _userListViewModel;
            }
        }
    }
}