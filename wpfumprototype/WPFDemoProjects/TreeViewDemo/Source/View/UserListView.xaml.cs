using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using TreeViewDemo.Source.ViewModel;

namespace TreeViewDemo.Source.View {
    /// <summary>
    /// Interaction logic for UserListView.xaml
    /// </summary>
    public partial class UserListView : UserControl {
        private SortAdorner _curAdorner;
        private GridViewColumnHeader _curSortCol;

        public UserListView() {
            InitializeComponent();
        }

        private void SortClick(object sender, RoutedEventArgs e) {
            var column = sender as GridViewColumnHeader;
            var propertyName = column.Tag as string;

            if (_curSortCol != null) {
                AdornerLayer.GetAdornerLayer(_curSortCol).Remove(_curAdorner);
                _listView.Items.SortDescriptions.Clear();
            }

            ListSortDirection direction = ListSortDirection.Ascending;
            if (_curSortCol == column && _curAdorner.Direction == direction) {
                direction = ListSortDirection.Descending;
            }

            _curSortCol = column;
            _curAdorner = new SortAdorner(_curSortCol, direction);

            AdornerLayer.GetAdornerLayer(_curSortCol).Add(_curAdorner);
            _listView.Items.SortDescriptions.Add(new SortDescription(propertyName, direction));
        }

        private void OnDoubleClick(object sender, MouseButtonEventArgs e) {
            //var userViewModel = ((ListViewItem) sender).Content as UserViewModel; //Casting back to the binded Track}
            var userViewModelNew = ((ListViewItem)sender).Content as UserViewModelNew; //Casting back to the binded Track}
            if (userViewModelNew == null) {
                MessageBox.Show("Impossible", "Unexpected Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            //var page = new UserDetailPage(userViewModel);
            var page = new UserDetailPageNew(userViewModelNew);
            NavigationService.GetNavigationService(this).Navigate(page);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
        }

        private void _listView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var model = DataContext as UserListViewModel;
            if (model != null) {
                model.CurrentUser = _listView.SelectedItem as UserViewModelNew;
            }
        }
    }
}