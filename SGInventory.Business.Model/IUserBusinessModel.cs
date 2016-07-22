using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Business.Model
{
    public interface IUserBusinessModel : IBusinessTransact<User>, IValidate<User>, ISave<User>, ISelectAll<User>, ISelectByPrimary<User, int>
    {
        User LogIn(string userName, string password);

        User SelectUserByUserName(string userName);
    }
}
