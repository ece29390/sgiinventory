using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Views;
using SGInventory.Model;

namespace SGInventory.Presenters
{
    public interface IStoreEditView : SGInventory.Views.ICode, IEventEditView<Store>, IEditViewName, IEditViewLoadData<Store>, IMessageBox, IEditViewUser, IOnModelUpdateSuccessful<Store>
    {
    }
}
