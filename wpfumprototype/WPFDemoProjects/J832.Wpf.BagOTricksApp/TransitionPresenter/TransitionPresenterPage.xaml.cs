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
using System.Windows.Threading;
using System.Reflection;
using System.Collections;


namespace Microsoft.Samples.KMoore.WPFSamples.Transition
{
    public partial class TransitionPresenterPage : Page
    {
        public TransitionPresenterPage()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, object e)
        {
            IList<string> pictures = Helpers.GetPicturePaths();
            PropertyInfo[] props = typeof(Brushes).GetProperties();

            List<object> data = new List<object>(17);

            data.Add(new UI());

            for (int i = 0; i < Math.Min(pictures.Count, 8); i++)
            {
                data.Add(new Picture(pictures[i]));
            }

            for (int i = 0; i < Math.Min(props.Length, 8); i++)
            {
                if (props[i].Name != "Transparent")
                {
                    data.Add(new Swatch(props[i].Name));
                }
            }

            this.DataContext = _data.ItemsSource = data;


            // Setup 2 way transitions
            Transition[] transitions = (Transition[])FindResource("ForwardBackTransitions");

            for (int i = 0; i < transitions.Length; i += 2)
            {
                ListTransitionSelector selector = new ListTransitionSelector(transitions[i], transitions[i + 1], data);
                TextSearch.SetText(selector, TextSearch.GetText(transitions[i]));
                _selectors.Items.Add(selector);
            }
        }

        private void OnMouseLeftDown(object s, MouseEventArgs e)
        {
            _data.SelectedIndex = (_data.SelectedIndex + 1) % _data.Items.Count;
            _data.ScrollIntoView(_data.SelectedItem);
        }

        private void OnMouseRightDown(object s, MouseEventArgs e)
        {
            _data.SelectedIndex = (_data.SelectedIndex + _data.Items.Count - 1) % _data.Items.Count;
            _data.ScrollIntoView(_data.SelectedItem);
        }

        private void OnModeChanged(object s, object e)
        {
            if (!_twoWay.IsSelected) _selectors.SelectedIndex = -1;
        }
    }

    class ListTransitionSelector : TransitionSelector
    {
        public ListTransitionSelector(Transition forward, Transition backward, IList list)
        {
            _forward = forward;
            _backward = backward;
            _list = list;
        }

        public override Transition SelectTransition(object oldContent, object newContent)
        {
            int oldIndex = _list.IndexOf(oldContent);
            int newIndex = _list.IndexOf(newContent);
            return newIndex > oldIndex ? _forward : _backward;
        }

        private Transition _forward, _backward;
        private IList _list;
    }

    internal class UI
    {
    }

    internal class Picture
    {
        public Picture(string uri)
        {
            _uri = uri;
        }

        public string Uri
        {
            get { return _uri; }
        }

        private readonly string _uri;

    }

    internal class Swatch
    {
        public Swatch(string colorName)
        {
            _colorName = colorName;
        }

        public string ColorName
        {
            get { return _colorName; }
        }

        private readonly string _colorName;
    }
}
