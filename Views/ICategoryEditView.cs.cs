using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.CustomEventArgs;

namespace SGInventory.Views
{
    public interface ICategoryEditView:IEventEditView<Category>,IEditViewName,IEditViewUser,IEditViewLoadData<Category>,IMessageBox
    {               
        string GetDescription();
        
    }
}
