using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Views
{
    public interface IChangePasswordView:IShowMessage,ICloseForm
    {
        string GetUserName();

        string ConfirmationOldPassword();

        string NewPassword();
       
    }
}
