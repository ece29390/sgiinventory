using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Presenters
{
    public class ChangePasswordPresenter
    {
       
        private Business.Model.IUserBusinessModel _userBusinessModel;
        private Views.IChangePasswordView _changePasswordView;

        public ChangePasswordPresenter(Business.Model.IUserBusinessModel iUserBusinessModel, Views.IChangePasswordView iChangePasswordView)
        {         
            this._userBusinessModel = iUserBusinessModel;
            this._changePasswordView = iChangePasswordView;
        }
       
        public void ProcessNewPassword()
        {
            var userName = _changePasswordView.GetUserName();

            var user = _userBusinessModel.SelectUserByUserName(userName);

            if (user.Password != _changePasswordView.ConfirmationOldPassword())
            {
                _changePasswordView.ShowMessage("The Old Password is not valid");
                return;
            }

            user.Password = _changePasswordView.NewPassword();
            user.ModifiedBy = userName;
            user.ModifiedDate = DateTime.Now;

            _userBusinessModel.CreateOrUpdate(user);
            _changePasswordView.ShowMessage("Password has been successfully changed");
            _changePasswordView.CloseForm();

        }
    }
}
