using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Data;

namespace TreeViewDemo.Controls
{
    public class ImagePathConverter : IValueConverter
    {
        #region IValueConverter Members

        private static string path;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (path == null)
            {
                path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))) + "\\Images";
                if (!Directory.Exists(path))
                {
                    path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Images";
                    if (!Directory.Exists(path))
                    {
                        //throw new FileNotFoundException("Can't find images folder", path);
                    }
                }
                path += "\\";
            }
            return string.Format("{0}{1}", path, (string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
