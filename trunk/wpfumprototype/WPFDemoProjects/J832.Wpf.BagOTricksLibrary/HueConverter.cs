﻿/*
The MIT License

Copyright (c) 2008 Kevin Moore (http://j832.com)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Windows.Data;
using System.Windows.Media;
using J832.Common;

namespace J832.Wpf
{
    public class HueConverter : IValueConverter
    {
        public Color Convert(int index, int count)
        {
            Util.RequireArgumentRange(index >= 0, "index");
            Util.RequireArgumentRange(count > 0, "count");

            index = index % count;

            return WpfUtil.HsbToRgb(index / (float)count, Saturation, Brightness);
        }

        public float Saturation { get; set; }
        public float Brightness { get; set; }

        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || parameter == null)
            {
                return null;
            }

            int index;
            if (value is int)
            {
                index = (int)value;
            }
            else if (value is string)
            {
                index = int.Parse((string)value);
            }
            else if (value is char)
            {
                index = (int)(char)value;
            }
            else
            {
                throw new ArgumentException();
            }

            int count;
            if (parameter is int)
            {
                count = (int)parameter;
            }
            else if (parameter is string)
            {
                count = int.Parse((string)parameter);
            }
            else
            {
                throw new ArgumentException();
            }

            Color color = Convert(index, count);

            if (targetType.IsAssignableFrom(typeof(SolidColorBrush)))
            {
                if (m_brushCache.ContainsKey(color))
                {
                    return m_brushCache[color];
                }
                else if (m_brushCache.Count < 20)
                {
                    SolidColorBrush brush = new SolidColorBrush(color);
                    brush.Freeze();
                    m_brushCache.Add(color, brush);
                    return brush;
                }
                else
                {
                    SolidColorBrush brush = new SolidColorBrush(color);
                    brush.Freeze();
                    return brush;
                }
            }
            else
            {
                return color;
            }
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        private readonly Dictionary<Color, SolidColorBrush> m_brushCache = new Dictionary<Color, SolidColorBrush>();

    }
}