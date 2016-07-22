using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Business.Model
{
    public class UserBusinessModel:IUserBusinessModel
    {
        private Dal.IUserDal _iUserDal;

        public UserBusinessModel(Dal.IUserDal iUserDal)
        {            
            this._iUserDal = iUserDal;
        }

        public List<SGInventory.Model.User> SelectAll()
        {
            return this._iUserDal.SelectAll();
        }

        public SGInventory.Model.User SelectByPrimaryId(int primaryId)
        {
            return this._iUserDal.SelectPrimaryEntity<int>(primaryId);
        }

        public bool Valid(SGInventory.Model.User model)
        {
            var returnValue = true;            
            var returnUser = SelectUserByUserName(model.UserName);

            if (returnUser != null)
            {
                returnValue = returnUser.Id == model.Id;
            }

            return returnValue;
        }

        public void Delete(SGInventory.Model.User model)
        {
            this._iUserDal.Delete(model);
        }

        public string Save(SGInventory.Model.User model)
        {
            if (Valid(model))
            {
                var previousId = model.Id;
                CreateOrUpdate(model);
                return previousId > 0 ? "User has been updated" : "A new User has been added";
            }

            return string.Format("{0} already exists", model.UserName);
        }

        public void CreateOrUpdate(SGInventory.Model.User model)
        {
            this._iUserDal.SaveOrUpdate(model);
        }

        public SGInventory.Model.User LogIn(string userName, string password)
        {           
            var parameterName = "userName";
            var passwordParameter = "password";

            var spQuery = string.Format("CALL UserLogin(:{0},:{1})", parameterName,passwordParameter);

            var parameters = new Dictionary<string, object> { 
                {parameterName,userName},
                {passwordParameter,password}
            };

            var returnList = _iUserDal.SelectBySpQuery(spQuery, parameters);
            User returnUser = null;

            if (returnList.Count > 0)
            {
                returnUser = returnList[0];
            }

            return returnUser;
        }


        public User SelectUserByUserName(string userName)
        {            
            var parameterName = "userName";

            var spQuery = string.Format("CALL SelectUserByUserName(:{0})", parameterName);

            var parameters = new Dictionary<string, object> { 
                {parameterName,userName}
            };

            var returnList = _iUserDal.SelectBySpQuery(spQuery, parameters);

            User returnUser = returnList.Count > 0 ? returnList[0] : null;

            return returnUser;
        }
    }
}
