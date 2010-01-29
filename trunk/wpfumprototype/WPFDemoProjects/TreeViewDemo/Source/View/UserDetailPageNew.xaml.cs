using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TreeViewDemo.Source.ViewModel;

namespace TreeViewDemo.Source.View
{
    /// <summary>
    /// Interaction logic for UserDetailPageNew.xaml
    /// </summary>
    public partial class UserDetailPageNew : Page
    {
        private readonly UserViewModelNew _userViewModel;
        private readonly UserViewModelNew _originalUserModel;
        
        public UserDetailPageNew():this(null)
        {
        }

        public UserDetailPageNew(UserViewModelNew userViewModel)
        {
            InitializeComponent();
            if (userViewModel != null)
            {
                _userViewModel = userViewModel.Clone();
                _originalUserModel = userViewModel;
                Title = "User Details";
                //_userNameTbx.IsEnabled = false;
            }
            else
            {
                _userViewModel = new UserViewModelNew();
                Title = "Add User";
                _userViewModel.IsReadOnlyUserName = true;
            }

            DataContext = _userViewModel;

            CommandBindings.Add(new CommandBinding(NavigationCommands.BrowseHome, GoHomeExecuted, CommandCanExecute));
            CommandBindings.Add(new CommandBinding(NavigationCommands.BrowseBack, GoHomeExecuted, CommandCanExecute));
        }

        private void GoHomeExecuted(object target, ExecutedRoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Can always navigate home
            e.CanExecute = true;
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            _userViewModel.SubmitChanges();
            NavigationService.Navigate(new Uri("pack://application:,,,/Source/UsersDemoPage.xaml"));
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            if (_originalUserModel != null)
            {
                _userViewModel.RestoreState(_originalUserModel);
            }
            NavigationService.Navigate(new Uri("pack://application:,,,/Source/UsersDemoPage.xaml"));
        }
    }
}
