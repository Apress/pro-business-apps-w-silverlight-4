using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SimpleMVVM;

namespace AdventureWorks.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region Member Variables
        private string _userName;
        private string _password;
        #endregion

        #region Evens
        public event EventHandler LoginSuccessful;
        public event EventHandler LoginFailed;
        public event EventHandler LoginError; 
        #endregion

        #region Public Properties
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged(() => UserName);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(() => Password);
            }
        } 
        #endregion

        #region Commands (plus supporting methods)
        public ICommand Login
        {
            get
            {
                return new DelegateCommand(BeginLogin, CanLogin);
            }
        }

        public void BeginLogin(object param)
        {
            // Logic to validate the user's login goes here.  We'll assume the
            // credentials are immediately valid (you'd normally go back to the
            // server first), and raise the LoginSuccessful event
            if (LoginSuccessful != null)
                LoginSuccessful(this, new EventArgs());
        }

        private bool CanLogin(object param)
        {
            if (param != null && param.GetType() == typeof(bool))
                return (bool)param;
            else
                return true;
        }
        #endregion
    }
}
