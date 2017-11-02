using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Presenters
{
    public class LoginPresenter
    {
        private Business.Model.IUserBusinessModel _userBusinessModel;
        private Business.Model.IUserBusinessModel iUserBusinessModel;
        private Views.ILoginView _loginView;
      
        public LoginPresenter(Business.Model.IUserBusinessModel iUserBusinessModel, Views.ILoginView iLoginView)
        {            
            this._userBusinessModel = iUserBusinessModel;
            this._loginView = iLoginView;            
        }

        public void LogIn(string userName, string password)
        {
            var user = this._userBusinessModel.LogIn(userName, password);

            if (user != null)
            {
                this._loginView.SetUserProfile(user);
                this._loginView.SetUserSettings(user);
                this._loginView.CloseForm();
            }
            else
            {
                this._loginView.ShowMessage("Invalid Username or password");
            }
        }

        public void OnTextPressEnter(string userName, string password)
        {
            if(!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password) && _loginView.IsButtonEnable())
            {
                LogIn(userName, password);
            }
        }
    }
}
