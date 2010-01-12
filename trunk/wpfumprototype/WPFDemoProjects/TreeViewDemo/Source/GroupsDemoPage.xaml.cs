using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TreeViewDemo.Source.View;
using TreeViewDemo.Source.ViewModel;

namespace TreeViewDemo.Source {
    /// <summary>
    /// Interaction logic for GroupsDemoPage.xaml
    /// </summary>
    public partial class GroupsDemoPage : Page {
        private readonly GroupsPageViewModel _viewModel;

        public GroupsDemoPage() {
            InitializeComponent();

            _viewModel = new GroupsPageViewModel();
            DataContext = _viewModel;
        }

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                _viewModel.GroupsTreeViewModel.SearchCommand.Execute(null);
            }
        }

        private void OnItemSelected(object source, RoutedEventArgs e) {
            var view = e.OriginalSource as GroupTreeView;
            _viewModel.CurrentGroup = view.Selected;
        }
    }
}