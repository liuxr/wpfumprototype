using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BusinessLib.DataAccess;
using TreeViewDemo.Source.ViewModel;

namespace TreeViewDemo.Source.View {
    /// <summary>
    /// Interaction logic for UserDetailPage.xaml
    /// </summary>
    public partial class UserDetailPage : Page {
        private readonly GroupsTreeViewModel _groupsTreeViewModel;
        private readonly UserViewModel _userViewModel;
        private readonly UserViewModel _originalUserModel;

        public UserDetailPage()
                : this(null) {
        }

        public UserDetailPage(UserViewModel userViewModel) {
            InitializeComponent();
            if (userViewModel != null) {
                _userViewModel = userViewModel.Clone();
                _originalUserModel = userViewModel;
                Title = "User Details";
                _userNameTbx.IsEnabled = false;
            } else {
                _userViewModel = new UserViewModel();
                Title = "Add User";
            }
            DataContext = _userViewModel;
            _groupsTreeViewModel = new GroupsTreeViewModel(FakeDataService.GetGroupsTree());
            _candidateGroupsTree.DataContext = _groupsTreeViewModel;
           
            membershipListBox.SelectionChanged += membershipListBox_SelectionChanged;
            membershipListBox.Loaded += membershipListBox_Loaded;

            CommandBindings.Add(new CommandBinding(NavigationCommands.BrowseHome, GoHomeExecuted, CommandCanExecute));
            CommandBindings.Add(new CommandBinding(NavigationCommands.BrowseBack, GoHomeExecuted, CommandCanExecute));
        }

        private void GoHomeExecuted(object target, ExecutedRoutedEventArgs e) {
            NavigationService.GoBack();
        }

        private void CommandCanExecute(object sender, CanExecuteRoutedEventArgs e) {
            // Can always navigate home
            e.CanExecute = true;
        }

        private void membershipListBox_Loaded(object sender, RoutedEventArgs e) {
            if (membershipListBox.Items.Count > 0) {
                membershipListBox.SelectedIndex = 0;
            }
        }

        private void membershipListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            _removeGrpBtn.IsEnabled = membershipListBox.SelectedIndex != -1;
        }

        private void removeGroupBtnClick(object sender, RoutedEventArgs e) {
            var model = membershipListBox.SelectedValue as GroupViewModel;
            if (model != null) {
                int index = membershipListBox.SelectedIndex;
                _userViewModel.RemoveGroupMembership(model);
                if (index < membershipListBox.Items.Count) {
                    membershipListBox.SelectedIndex = index;
                } else if (membershipListBox.Items.Count > 0) {
                    membershipListBox.SelectedIndex = 0;
                }
            }
        }

        private void addGroupBtnClick(object sender, RoutedEventArgs e) {
            var model = _candidateGroupsTree.SelectedValue as GroupViewModel;
            if (model != null) {
                _userViewModel.AddGroupMembership(model);
                if (membershipListBox.Items.Count > 0) {
                    membershipListBox.SelectedIndex = membershipListBox.Items.Count - 1;
                }
            }
        }

        private void Submit(object sender, RoutedEventArgs e) {
            _userViewModel.SubmitChanges();
            NavigationService.Navigate(new Uri("pack://application:,,,/Source/UsersDemoPage.xaml"));
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            if(_originalUserModel != null) {
                _userViewModel.RestoreState(_originalUserModel);
            }
            NavigationService.Navigate(new Uri("pack://application:,,,/Source/UsersDemoPage.xaml"));
        }
    }
}