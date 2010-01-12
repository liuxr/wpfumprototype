using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using BusinessLib.DataAccess;
using BusinessLib.DataModel;
using TreeViewDemo.Source.ViewModel;

namespace TreeViewDemo.Source.Formatting {
    [ValueConversion(typeof (string), typeof (ReadOnlyCollection<GroupViewModel>))]
    public class UserMembershipConverter : IValueConverter {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var membership = value as string;
            if (membership != null) {
                string[] groupNames = membership.Split(new[] { " ," }, StringSplitOptions.RemoveEmptyEntries);
                Group[] groups = FakeDataService.GetGroups(groupNames);
                return new ReadOnlyCollection<GroupViewModel>(
                        (from g in groups select new GroupViewModel(g)).ToList()
                        );
            }
            return new ReadOnlyCollection<GroupViewModel>(new List<GroupViewModel>());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            // we don't intend this to ever be called
            return null;
        }

        #endregion
    }
}