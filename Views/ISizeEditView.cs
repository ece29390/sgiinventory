using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;


namespace SGInventory.Views
{
    public interface ISizeEditView :ICode, IEventEditView<Size>, IEditViewName, IEditViewLoadData<Size>, IMessageBox, IEditViewUser,IOnModelUpdateSuccessful<Size>
    {
        
    }
}
