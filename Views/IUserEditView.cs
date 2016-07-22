using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Views
{
    public interface IUserEditView:IEventEditView<User>, IEditViewName, IEditViewUser, IEditViewLoadData<User>, IMessageBox
    {
        string GetPassword();
        string UserName();
        void LoadRoleTypes();
        int GetRoleTypeValue();
    }
}
