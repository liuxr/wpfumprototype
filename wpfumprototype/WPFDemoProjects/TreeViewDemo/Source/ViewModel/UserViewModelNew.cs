using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using BusinessLib.DataAccess;
using BusinessLib.DataModel;

namespace TreeViewDemo.Source.ViewModel
{
    public class UserViewModelNew : BaseViewModel
    {
        private readonly User _user;
        private bool _isReadonlyUserName = false;
        public UserViewModelNew()
            : this(null)
        {
        }

        public UserViewModelNew(User user)
        {
            _user = user;
            // Create new and assign default value
            if (user == null)
            {
                _user = new User("<User Name>");
            }
        }

        public User User
        {
            get { return _user; }
        }

        
        public string UserName
        {
            get
            {
                return _user.UserName;
            }
            set
            {
                if (_user.UserName != value)
                {
                    _user.UserName = value;
                    OnPropertyChanged("UserName");
                }
            }
        }

        public bool IsReadOnlyUserName
        {
            get
            {
                return _isReadonlyUserName;
            }
            set
            {
                _isReadonlyUserName = value;
            }
        }

        // Path to image
        public string UserIcon
        {
            get
            {
                return _user.UserIcon;
            } set
            {
                _user.UserIcon = value;
            }
        }

        public string Description
        {
            get
            {
                return _user.Description;
            }
            set
            {
                if (_user.Description != value)
                {
                    _user.Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public string FullName
        {
            get { return _user.FullName; }
            set
            {
                if (_user.FullName != value)
                {
                    _user.FullName = value;
                    OnPropertyChanged("FullName");
                }
            }
        }

        public string Title
        {
            get { return _user.Title; }
            set
            {
                if (_user.Title != value)
                {
                    _user.Title = value;
                    OnPropertyChanged("Title");
                }
            }
        }
        public bool EnableStdAuthentication
        {
            get { return _user.EnableStdAuthentication; }
            set
            {
                if (_user.EnableStdAuthentication != value)
                {
                    _user.EnableStdAuthentication = value;
                    OnPropertyChanged("EnableStdAuthentication");
                }
            }
        }
        public string Password
        {
            get { return _user.Password; }
            set
            {
                if (_user.Password != value)
                {
                    _user.Password = value;
                    OnPropertyChanged("Password");
                }
            }
        }
        public bool ChangePassword
        {
            get { return _user.ChangePassword; }
            set
            {
                if (_user.ChangePassword != value)
                {
                    _user.ChangePassword = value;
                    OnPropertyChanged("ChangePassword");
                }
            }
        }
        public string PreferredLanguage
        {
            get { return _user.PreferredLanguage; }
            set
            {
                if (_user.PreferredLanguage != value)
                {
                    _user.PreferredLanguage = value;
                    OnPropertyChanged("PreferredLanguage");
                }
            }
        }
        public string Email
        {
            get { return _user.Email; }
            set
            {
                if (_user.Email != value)
                {
                    _user.Email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        public DateTime LastLogonDate
        {
            get { return _user.LastLogonDate; }
            set
            {
                if (_user.LastLogonDate != value)
                {
                    _user.LastLogonDate = value;
                    OnPropertyChanged("LastLogonDate");
                }
            }
        }
        public LockStatus LockStatus
        {
            get { return _user.LockStatus; }
            set
            {
                if (_user.LockStatus != value)
                {
                    _user.LockStatus = value;
                    OnPropertyChanged("LockStatus");
                }
            }
        }
        public int InvalidAuthenticationCount
        {
            get { return _user.InvalidAuthCount; }
            set
            {
                if (_user.InvalidAuthCount != value)
                {
                    _user.InvalidAuthCount = value;
                    OnPropertyChanged("InvalidAuthenticationCount");
                }
            }
        }

        //Windows Authentication tab
        public bool EnableWindowsAuth
        {
            get { return _user.EnableWindowsAuth; }
            set
            {
                if (_user.EnableWindowsAuth != value)
                {
                    _user.EnableWindowsAuth = value;
                    OnPropertyChanged("EnableWindowsAuth");
                }
            }
        }
        public string WindowsAccount
        {
            get { return _user.WindowsAccount; }
            set
            {
                if (_user.WindowsAccount != value)
                {
                    _user.WindowsAccount = value;
                    OnPropertyChanged("WindowsAccount");
                }
            }
        }

        //Sun5 plugin tab
        public string OperatorCode
        {
            get { return _user.OperatorCode; }
            set
            {
                if (_user.OperatorCode != value)
                {
                    _user.OperatorCode = value;
                    OnPropertyChanged("OperatorCode");
                }
            }
        }
        public string LookupCode
        {
            get { return _user.LookupCode; }
            set
            {
                if (_user.LookupCode != value)
                {
                    _user.LookupCode = value;
                    OnPropertyChanged("LookupCode");
                }
            }
        }
        public string ShortHeading
        {
            get { return _user.ShortHeading; }
            set
            {
                if (_user.ShortHeading != value)
                {
                    _user.ShortHeading = value;
                    OnPropertyChanged("ShortHeading");
                }
            }
        }
        public string DefaultBusinessUnit
        {
            get { return _user.DefaultBusinessUnit; }
            set
            {
                if (_user.DefaultBusinessUnit != value)
                {
                    _user.DefaultBusinessUnit = value;
                    OnPropertyChanged("DefaultBusinessUnit");
                }
            }
        }
        public string Sun5Language
        {
            get { return _user.Sun5Language; }
            set
            {
                if (_user.Sun5Language != value)
                {
                    _user.Sun5Language = value;
                    OnPropertyChanged("Sun5Language");
                }
            }
        }
        public string DefaultLedger
        {
            get { return _user.DefaultLedger; }
            set
            {
                if (_user.DefaultLedger != value)
                {
                    _user.DefaultLedger = value;
                    OnPropertyChanged("DefaultLedger");
                }
            }
        }
        public string TemporaryWorkFolder
        {
            get { return _user.TemporaryWorkFolder; }
            set
            {
                if (_user.TemporaryWorkFolder != value)
                {
                    _user.TemporaryWorkFolder = value;
                    OnPropertyChanged("TemporaryWorkFolder");
                }
            }
        }

        //Sun5 Authorization tab
        public bool EnableSun5Authorizer
        {
            get { return _user.EnableSun5Authorizer; }
            set
            {
                if (_user.EnableSun5Authorizer != value)
                {
                    _user.EnableSun5Authorizer = value;
                    OnPropertyChanged("EnableSun5Authorizer");
                }
            }
        }
        public string AuthorizationPassword
        {
            get { return _user.AuthorizationPassword; }
            set
            {
                if (_user.AuthorizationPassword != value)
                {
                    _user.AuthorizationPassword = value;
                    OnPropertyChanged("AuthorizationPassword");
                }
            }
        }
        public int InvalidAuthorizationCount
        {
            get { return _user.InvalidAuthorizationCount; }
            set
            {
                if (_user.InvalidAuthorizationCount != value)
                {
                    _user.InvalidAuthorizationCount = value;
                    OnPropertyChanged("InvalidAuthorizationCount");
                }
            }
        }

        //Directory Serivce tab
        public bool EnableDirectoryAuth
        {
            get { return _user.EnableDirectoryAuth; }
            set
            {
                if (_user.EnableDirectoryAuth != value)
                {
                    _user.EnableDirectoryAuth = value;
                    OnPropertyChanged("EnableDirectoryAuth");
                }
            }
        }
        public string DirectoryServiceAccount
        {
            get { return _user.DirectoryServiceAccount; }
            set
            {
                if (_user.DirectoryServiceAccount != value)
                {
                    _user.DirectoryServiceAccount = value;
                    OnPropertyChanged("DirectoryServiceAccount");
                }
            }
        }

        public string Membership
        {
            get
            {
                return _user.GetMembershipString();
            }
        }

        public void RemoveGroupMembership(GroupViewModel model)
        {
            _user.RemoveGroupMembership(model.Name);
            OnPropertyChanged("Membership");
        }

        public void AddGroupMembership(GroupViewModel model)
        {
            _user.AddGroupMembership(model.Name);
            OnPropertyChanged("Membership");
        }

        public void SubmitChanges()
        {
            FakeDataService.UpdateUser(_user);
        }

        public UserViewModelNew Clone()
        {
            var clone = new UserViewModelNew();
            clone.UserName = UserName;
            clone.Description = Description;
            foreach (Group group in _user.GroupMembership)
            {
                clone.AddGroupMembership(new GroupViewModel(group));
            }
            clone.FullName = FullName;
            clone.UserIcon = UserIcon;
            clone.Title = Title;
            clone.EnableStdAuthentication = EnableStdAuthentication;
            clone.Password = Password;
            clone.PreferredLanguage = PreferredLanguage;
            clone.Email = Email;
            clone.LastLogonDate = LastLogonDate;
            clone.LockStatus = LockStatus;
            clone.InvalidAuthenticationCount = InvalidAuthenticationCount;
            clone.EnableWindowsAuth = EnableWindowsAuth;
            clone.OperatorCode = OperatorCode;
            clone.LookupCode = LookupCode;
            clone.ShortHeading = ShortHeading;
            clone.DefaultBusinessUnit = DefaultBusinessUnit;
            clone.Sun5Language = Sun5Language;
            clone.DefaultLedger = DefaultLedger;
            clone.TemporaryWorkFolder = TemporaryWorkFolder;
            clone.EnableSun5Authorizer = EnableSun5Authorizer;
            clone.AuthorizationPassword = AuthorizationPassword;
            clone.InvalidAuthorizationCount = InvalidAuthorizationCount;
            clone.EnableDirectoryAuth = EnableDirectoryAuth;
            clone.DirectoryServiceAccount = DirectoryServiceAccount;

            return clone;
        }

        public void RestoreState(UserViewModelNew model)
        {
            if (model != null)
            {
                UserName = model.UserName;
                Description = model.Description;
                _user.GroupMembership.Clear();
                foreach (Group group in model._user.GroupMembership)
                {
                    AddGroupMembership(new GroupViewModel(group));
                }
            }
        }

        public void Delete()
        {
            FakeDataService.DeleteUser(_user);
        }

        public List<String> PreferredLanguagesList
        {
            get { return BusinessLib.DataModel.PreferredLanguage.Instance.SupportedLanguages; }
        }
    }
}
