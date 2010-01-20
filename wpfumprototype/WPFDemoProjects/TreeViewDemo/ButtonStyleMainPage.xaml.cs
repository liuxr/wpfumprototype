using System;
using System.Windows;
using System.Windows.Controls;
using TreeViewDemo.Source.Commands;

namespace TreeViewDemo {
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page {
        private DeleteUserCommand _deleteUserCMD;

        public MainPage() {
            InitializeComponent();
//            _deleteUserCMD = new DeleteUserCommand();
            //this.CommandBindings.Add(new CommandBinding(_addUserCMD));
            //this.CommandBindings.Add(new CommandBinding(_deleteUserCMD));
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Not implemented yet!", "Menu Not Avaiable", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void AddUser_Click(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new Uri("./source/view/userdetailview.xaml", UriKind.Relative));
        }
    }
}