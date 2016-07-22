using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Business.Model;
using SGInventory.Views;

namespace SGInventory.Presenters
{
    public class UserEditPresenter : EditPresenterBase<User>
    {
        private Views.IUserEditView _userEditView;
        private Business.Model.IUserBusinessModel _userBusinessModel;

        public UserEditPresenter(Views.IUserEditView iUserEditView
            , Business.Model.IUserBusinessModel iUserBusinessModel
            ,User model=null):base("User")
        {
            
            this._userEditView = iUserEditView;
            this._userBusinessModel = iUserBusinessModel;
            base._model = model;
        }

        public override void Save(Action<string, List<User>> callBackAfterSaving)
        {
            var userName = _userEditView.UserName();
            var password = _userEditView.GetPassword();
            var fullName = _userEditView.GetName();
            var roleType = _userEditView.GetRoleTypeValue();

            if (_model != null)
            {
                _model.UserName = userName;
                _model.Password = password;
                _model.Name = fullName;
                _model.ModifiedBy = _userEditView.GetUser();
                _model.ModifiedDate = DateTime.Now;
                _model.Roletype = roleType;
            }
            else
            {
                _model = new User { UserName = userName
                    , Name = fullName
                    , Password = password
                    , CreatedDate = DateTime.Now
                    , CreatedBy = _userEditView.GetUser() 
                    , Roletype = roleType
                };
            }
            var userNameLength = 20;
            if (userName.Trim().Length > userNameLength ? true : false)
            {
                _userEditView.ShowMessage(string.Format("Username has exceeded the maximum limit of {0} characters", userNameLength));
                return;
            }

            var nameLength = 100;
            if (fullName.Trim().Length > nameLength ? true : false)
            {
                _userEditView.ShowMessage(string.Format("Name has exceeded the maximum limit of {0} characters", nameLength));
                return;
            }

            var passwordLength=50;
            if (password.Trim().Length > passwordLength ? true : false)
            {
                _userEditView.ShowMessage(string.Format("Password has exceeded the maximum limit of {0} characters",passwordLength));
                return;
            }

            base.PersistChanges<IUserBusinessModel>(this._userBusinessModel, callBackAfterSaving);
        }

        public override void LoadModels(User model)
        {
            _model = model;
            base.LoadEntity<IUserEditView>(this._userEditView);
        }

        public override bool ShouldEnable()
        {
            return base.ShouldEnable(_userEditView.UserName()) && base.ShouldEnable(_userEditView.GetName()) && base.ShouldEnable(_userEditView.GetPassword());
        }

        public void LoadRoleTypes()
        {
            _userEditView.LoadRoleTypes();
        }
    }
}
