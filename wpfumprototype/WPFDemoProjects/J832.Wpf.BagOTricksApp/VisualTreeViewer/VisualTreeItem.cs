using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using J832.Common;

namespace Microsoft.Samples.KMoore.WPFSamples.VisualTreeViewer
{
    public class VisualTreeItem
    {
        public VisualTreeItem(DependencyObject element)
        {
            Util.RequireNotNull(element, "element");

            m_element = element;
        }

        public IEnumerable<VisualTreeItem> Children
        {
            get
            {
                if (_children == null)
                {
                    _children = new List<VisualTreeItem>(VisualTreeHelper.GetChildrenCount(m_element));
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(m_element); i++)
                    {
                        _children.Add(new VisualTreeItem(VisualTreeHelper.GetChild(m_element, i)));
                    }
                }
                return _children;
            }
        }

        public string Name
        {
            get
            {
                FrameworkElement fe = m_element as FrameworkElement;
                if (fe != null && !String.IsNullOrEmpty(fe.Name))
                {
                    return TypeName + ":" + fe.Name;
                }
                else
                {
                    return TypeName;
                }
            }
        }

        public string TypeName
        {
            get
            {
                return m_element.GetType().Name;
            }
        }

        public override string ToString()
        {
            return Name;
        }


        private List<VisualTreeItem> _children;
        private readonly DependencyObject m_element;

    }

}