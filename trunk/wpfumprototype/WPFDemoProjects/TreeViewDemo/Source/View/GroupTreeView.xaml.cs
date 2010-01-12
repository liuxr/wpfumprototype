using System.Windows;
using System.Windows.Controls;
using TreeViewDemo.Source.ViewModel;

namespace TreeViewDemo.Source.View {
    /// <summary>
    /// Interaction logic for GroupTreeView.xaml
    /// </summary>
    public partial class GroupTreeView : UserControl {
        public static readonly RoutedEvent GroupSelectedEvent = EventManager.RegisterRoutedEvent
                ("GroupSelected", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (GroupTreeView));

        public GroupTreeView() {
            InitializeComponent();
            _treeView.Loaded += Tree_Loaded;
        }

        public object SelectedValue {
            get {
                return _treeView.SelectedValue;
            }
        }

        public GroupViewModel Selected { get; set; }

        private void Tree_Loaded(object sender, RoutedEventArgs e) {
            var item = _treeView.ItemContainerGenerator.ContainerFromIndex(0) as TreeViewItem;
            if (item != null) {
                item.IsSelected = true;
            }
        }

        public event RoutedEventHandler GroupSelected {
            add {
                base.AddHandler(GroupSelectedEvent, value);
            }
            remove {
                base.RemoveHandler(GroupSelectedEvent, value);
            }
        }

        private void TreeViewItemSelected(object sender, RoutedEventArgs e) {
            var item = e.OriginalSource as TreeViewItem;
            if (item != null) {
                Selected = item.Header as GroupViewModel;
            }
            var arg = new RoutedEventArgs(GroupSelectedEvent, this);
            RaiseEvent(arg);
        }
    }
}