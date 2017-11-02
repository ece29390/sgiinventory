using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Views
{
    public interface ILoginView : IShowMessage,ICloseForm
    {
       void  SetUserProfile(Model.User user);

       void  SetUserSettings(Model.User user);
        bool IsButtonEnable();
    }
}
