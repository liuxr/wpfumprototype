using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BusinessLib.DataAccess;
using TreeViewDemo.Source.ViewModel;

namespace TreeViewDemo.Source {
    /// <summary>
    /// Interaction logic for UsersDemoPage.xaml
    /// </summary>
    public partial class UsersDemoPage : Page {
        private UserListViewModel _userListViewModel;

        public UsersDemoPage() {
            InitializeComponent();
            _userListViewModel = new UserListViewModel(FakeDataService.GetUsers());
            DataContext = _userListViewModel;
        }

        public UserListViewModel UserListViewModel {
            get {
                return _userListViewModel;
            }
        }
    }
}