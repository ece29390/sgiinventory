using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Dal
{
    public class UserDal:DalBase<User>,IUserDal
    {
        public UserDal(Helpers.ISgiHelper iSgiHelper) : base(iSgiHelper) { }


        public  List<User> SelectAll()
        {
            return _helper.DataHelper.SelectAll<User>();
        }

        public  User SelectPrimaryEntity<D>(D primaryValue)
        {
            return _helper.DataHelper.SelectPrimary<User, D>(primaryValue);
        }

        public  List<User> SelectBySpQuery(string spName, Dictionary<string, object> parameters)
        {
            return _helper.DataHelper.SelectSp<User>(spName, parameters);
        }

        public  void SaveOrUpdate(User entity)
        {
            _helper.DataHelper.SaveOrUpdate<User>(entity);
        }

        public  List<User> SelectBySpQuery(string spName)
        {
            return _helper.DataHelper.SelectSp<User>(spName);
        }

        public  void Delete(User model)
        {
             _helper.DataHelper.Delete<User>(model);
        }
    }
}
