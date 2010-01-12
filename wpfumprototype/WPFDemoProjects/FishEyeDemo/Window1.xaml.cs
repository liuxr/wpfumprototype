using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace FishEyeDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : System.Windows.Window
    {
        FishEyePanel fish;

        public Window1()
        {
            InitializeComponent();
        }

        void FishEye_Loaded(object sender, RoutedEventArgs e)
        {
            fish = (FishEyePanel)sender;
        }
    }
}
