using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using BusinessLib.DataModel;
using TreeViewDemo.Source.Commands;

namespace TreeViewDemo.Source.ViewModel {
    public class GroupsTreeViewModel : BaseViewModel {
        private readonly ReadOnlyCollection<GroupViewModel> _firstGeneration;
        private readonly SearchFamilyTreeCommand _searchCommand;
        private IEnumerator<GroupViewModel> _matchingPeopleEnumerator;
        private string _searchText = string.Empty;

        public GroupsTreeViewModel(params Group[] roots) {
            _firstGeneration = new ReadOnlyCollection<GroupViewModel>(
                    (from temp in roots select new GroupViewModel(temp)).ToList());
            _searchCommand = new SearchFamilyTreeCommand(this);
        }

        /// <summary>
        /// Returns the command used to execute a search in the family tree.
        /// </summary>
        public ICommand SearchCommand {
            get {
                return _searchCommand;
            }
        }

        public string SearchText {
            get {
                return _searchText;
            }
            set {
                if (value == _searchText) {
                    return;
                }

                _searchText = value;
                _matchingPeopleEnumerator = null;
            }
        }

        

        public ReadOnlyCollection<GroupViewModel> FirstGeneration {
            get {
                return _firstGeneration;
            }
        }

        public void PerformSearch() {
            if (_matchingPeopleEnumerator == null || !_matchingPeopleEnumerator.MoveNext()) {
                VerifyMatchingPepleEnumerator();
            }

            GroupViewModel group = _matchingPeopleEnumerator.Current;

            if (group == null) {
                return;
            }

            if (group.Parent != null) {
                group.Parent.IsExpanded = true;
            }

            group.IsSelected = true;
        }

        private void VerifyMatchingPepleEnumerator() {
            IEnumerable<GroupViewModel> matches = FindMatches(_searchText, _firstGeneration.ToArray());
            _matchingPeopleEnumerator = matches.GetEnumerator();
            if (!_matchingPeopleEnumerator.MoveNext()) {
                MessageBox.Show("No matching names were found.", "Try Again", MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
        }

        private IEnumerable<GroupViewModel> FindMatches(string text, params GroupViewModel[] groups) {
            foreach (GroupViewModel group in groups) {
                if (group.NameContainsText(SearchText)) {
                    yield return group;
                }
                foreach (GroupViewModel child in group.Children) {
                    foreach (GroupViewModel match in FindMatches(text, child)) {
                        yield return match;
                    }
                }
            }
        }
    }
}