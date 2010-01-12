using System;
using System.Windows;
using System.Windows.Controls;

namespace RadialPanelDemo
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            // whenever one of the buttons is clicked, handle it in the same place
            foreach (Button button in radialPanel.Children)
            {
                button.Click += new RoutedEventHandler(OnButtonClick);
            }
        }

        void OnButtonClick(object sender, RoutedEventArgs e)
        {
            // find out who was clicked
            Button button = (Button)e.OriginalSource;

            // increment angle by 15 degrees
            RadialPanel.SetAngle(button, RadialPanel.GetAngle(button) + 15.0);
        }
    }
}