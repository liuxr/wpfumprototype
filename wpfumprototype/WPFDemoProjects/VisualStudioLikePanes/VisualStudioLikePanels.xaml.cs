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

namespace VisualStudioLikePanes
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private ColumnDefinition panel1ClonePanel;
        public Window1()
        {
            InitializeComponent();
            panel1ClonePanel = new ColumnDefinition();
            panel1ClonePanel.SharedSizeGroup = "column1";
        }

        private void buttonPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            layer1.Visibility = Visibility.Visible;
            parentGrid.Children.Remove(layer1);
            parentGrid.Children.Add(layer1);
        }

        private void layer0_MouseEnter(object sender, MouseEventArgs e)
        {
            if(panel1Button.Visibility==Visibility.Visible)
            {
                panel1Button.Visibility = Visibility.Visible;
                layer1.Visibility = Visibility.Collapsed;
            }
        }

        private void panel1Pin_Click(object sender, RoutedEventArgs e)
        {
            if (panel1Button.Visibility == Visibility.Visible)
            {
                layer0.ColumnDefinitions.Add(panel1ClonePanel);
                panel1Button.Visibility = Visibility.Collapsed;
                layer1.Visibility = Visibility.Visible;
            }else
            {
                layer0.ColumnDefinitions.Remove(panel1ClonePanel);
                panel1Button.Visibility = Visibility.Visible;

            }
        }
    }
}
