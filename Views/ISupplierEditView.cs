using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Views
{
    public interface ISupplierEditView : IEventEditView<Supplier>, IEditViewName, IEditViewAddress, IEditViewUser, IEditViewLoadData<Supplier>, IMessageBox
    {
        
    }
}
