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
using System.Xml;
using System.IO;

namespace XMLDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class LoadXMLWindow : Window
    {
        public LoadXMLWindow()
        {
            InitializeComponent();
        }

        private void _openBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                if (_urlBtn.IsChecked==true)
                {
                    doc.Load(_inputTbx.Text);
                }
                if (_streamBtn.IsChecked==true)
                {
                    FileStream stream = new FileStream(_inputTbx.Text, FileMode.Open);
                    doc.Load(stream);
                    stream.Close();
                }
                if (_stringBtn.IsChecked == true)
                {
                    doc.LoadXml(_inputTbx.Text);
                }

                MessageBox.Show(doc.DocumentElement.Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
