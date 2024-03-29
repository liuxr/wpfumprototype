﻿using System;
using System.Windows.Data;
using System.Windows.Media;

namespace Microsoft.Samples.KMoore.WPFSamples.ColorPicker
{
    public class ColorGradientConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string param = parameter as string;
            Color color = (Color)value;
            if (param != null)
            {
                switch (param)
                {
                    case "Red":
                        return new LinearGradientBrush(Color.FromRgb(0, color.G, color.B), Color.FromRgb(255, color.G, color.B), 0);
                    case "Green":
                        return new LinearGradientBrush(Color.FromRgb(color.R, 0, color.B), Color.FromRgb(color.R, 255, color.B), 0);
                    case "Blue":
                        return new LinearGradientBrush(Color.FromRgb(color.R, color.G, 0), Color.FromRgb(color.R, color.G, 255), 0);
                    default:
                        throw new ArgumentException("not valid value", "parameter");
                }
            }
            throw new ArgumentException("parameter not a string");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}