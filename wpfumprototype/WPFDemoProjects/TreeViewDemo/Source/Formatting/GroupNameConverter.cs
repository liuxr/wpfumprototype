using System;
using System.Globalization;
using System.Windows.Data;

namespace TreeViewDemo.Source.Formatting {
    [ValueConversion(typeof (string), typeof (string))]
    public class GroupNameConverter : IValueConverter {
        #region IValueConverter Members

        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture) {
            var formatString = parameter as string;

            return string.Format(formatString, value);
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture) {
            // we don't intend this to ever be called
            return null;
        }

        #endregion
    }
}